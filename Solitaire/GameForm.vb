Public Class GameForm

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    'Add any initialization after the InitializeComponent() call.
    Startup()

  End Sub

  Private m_settings As Settings

#Region "Member Variables"

  Private m_mouseX As Integer ' Current x position of mouse.
  Private m_mouseY As Integer ' Current y position of mouse.
  Private ReadOnly m_stacks As Array = Array.CreateInstance(GetType(Int32), 7, 5, 19) ' Stack array, (stack)(suit, card value, x, y, flipped)(index).
  Private ReadOnly m_deck As Array = Array.CreateInstance(GetType(Int32), 2, 24) ' Deck array, (suit, card value)(index).
  Private ReadOnly m_drop As Array = Array.CreateInstance(GetType(Int32), 4, 24) ' Drop array, (suit, card value, x, y)(index).
  Private ReadOnly m_drag As Array = Array.CreateInstance(GetType(Int32), 3, 13) ' Drag array, (suit, card value, y)(index).
  Private ReadOnly m_aceStacks As Array = Array.CreateInstance(GetType(Int32), 4, 2, 13) ' Ace drop array, (stack)(suit, card value)(index).
  Private ReadOnly m_stackLengths(6) As Integer ' Length of stack (one greater than last used index).
  Private m_deckLength As Integer = 0 ' Cards in dealing deck, -1 when flipping over deck.
  Private m_dropLength As Integer = 0 ' Cards in dropping deck.
  Private m_dragLength As Integer = 0 ' Cards in drag/drop action.
  Private ReadOnly m_aceStackLengths(3) As Integer ' Cards in each ace drop.
  Private ReadOnly m_random As New Random   ' Random number generator to shuffle deck.
  Private m_drawing As Boolean = False ' True when in process of drawing m_winParabola card from deck.
  Private m_hitCard As Integer ' Card that the mouse was over when dragging, needed for multiple card drag.
  Private m_dragStack As Integer ' Stack dragging cards were originally from: m_stacks < 7; DropPanelPictureBox = 7; aces>7.
  Private m_dragging As Boolean = False ' True when drag/drop in process.
  Private m_cycleDeck As Integer = 1 ' Number of times player has flipped the deck.
  Private m_win As Boolean = False ' False until user wins game.
  Private m_winStack As Integer = 0 ' Current stack during win effect.
  Private m_winCard As Integer = 12 ' Current card during win effect.
  Private m_winX As Integer ' X location of card during win effect.
  Private m_winY As Integer ' Y location of card during win effect.
  Private m_yMultiplier As Single = 0 ' Multiply Y intercept by this ratio during win effect.
  Private m_xMovement As Integer = 0 ' XShift on the win effect.
  Private m_xVertex As Integer = 0 ' Horizontal vertex value of current win parabola.
  Private m_yVertex As Integer = 0 ' Vertical vertex value of current win parabola.
  Private m_winParabola As Single = 0 ' Value of win parabola (y = ax ^ 2 + bx + c).
  Private m_newWinStack As Boolean = True ' True when new stack when displaying win effect.
  Private m_bounce As Boolean = False ' True if in same stack but bouncing, win effect.
  Private m_win2 As Boolean = False ' False until drag panel is set up for win effect.
  Private ReadOnly m_suit(3) As Integer ' Suits: spades=0, diamonds=1, clubs=2, hearts=3.
  Private ReadOnly m_aceLocation As Array = Array.CreateInstance(GetType(Integer), 2, 4) ' X, Y and suit for ace drops.
  Private m_undoType As Integer = 0 ' Undo type for switch and to get info from undo array.
  Private ReadOnly m_undo As Array = Array.CreateInstance(GetType(Integer), 7, 3) ' Keeps undo information, (type)(data).
  Private m_dragStartY As Integer = 0 ' The y to drop the card at, used for refresh problems.
  Private m_dragStartX As Integer = 0 ' The x to drop the card at, used for refresh problems.
  Private m_score As Integer = 0 ' Score if keeping score.
  Private m_time As Integer = 0 ' Time if keeping time.

#End Region

#Region "Graphical Layout Constants"

  Private ReadOnly m_xShift As Integer = 2 ' X shift for DropPanelPictureBox and DeckToDealPictureBox when Settings.DrawOne = True.
  Private ReadOnly m_yShift As Integer = 1 ' Y shift for DropPanelPictureBox and DeckToDealPictureBox.
  Private ReadOnly m_xBigShift As Integer = 15 ' DropPanelPictureBox X shift when Settings.DrawOne = False.
  Private ReadOnly m_small As Integer = 3 ' Unflipped card Y shift.
  Private ReadOnly m_large As Integer = 15 ' Flipped card Y shift.
  Private ReadOnly m_cardHeight As Integer = 96
  Private ReadOnly m_cardWidth As Integer = 71 ' Card width, must corespond to bmp or png width.

#End Region

  Private Sub Startup()

    CheatWinToolStripMenuItem.Visible = True ' for testing

    m_settings = Settings.Load()

    If Common.EnhancedMode Then
      If Not m_settings.Location.Equals(Point.Empty) AndAlso Not m_settings.Size.Equals(Size.Empty) Then
        Location = m_settings.Location
        'HACK: shorten the size by 20, somehow we are growing in height.
        Dim size As New Size(m_settings.Size.Width, m_settings.Size.Height - 20)
        Me.Size = size
      Else
        'TODO: should probably validate that the coordinates are visible on the screen.
        Dim x = (Screen.PrimaryScreen.WorkingArea.Width - Size.Width) \ 2
        Dim y = (Screen.PrimaryScreen.WorkingArea.Height - Size.Height) \ 2
        Location = New Point(x, y)
      End If
    Else
      StartPosition = FormStartPosition.WindowsDefaultLocation
      MinimumSize = New Size(0, 0)
    End If

    ' Deal Cards.
    Deal()

    ' Redo layout.
    WindowSizeChanged(Nothing, Nothing)

    ' Check user settings.
    UpdateStatus()

    ' Set drag panel.
    DragBoxPictureBox_1.BringToFront()
    DragBoxPictureBox_2.BringToFront()
    DragBoxPictureBox_3.BringToFront()
    DragBoxPictureBox_4.BringToFront()

  End Sub

  Private Sub Me_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    If Common.EnhancedMode Then
      m_settings.Location = Location
      m_settings.Size = Size
    Else
      m_settings.Location = Point.Empty
      m_settings.Size = Size.Empty
    End If
    Settings.Persist(m_settings)
  End Sub

  Private Sub GameTimer_Tick(sender As Object, e As EventArgs) Handles GameTimer.Tick
    m_time += 1
    If m_time Mod 10 = 0 Then
      m_score -= 2
    End If
    UpdateStatus()
  End Sub

#Region "Dealing/Shuffling Methods"

  Public Sub Deal()

    ' Temporary array for picking out cards (pseudoshuffle).
    Dim cards = Array.CreateInstance(GetType(Int32), 4, 13)
    Dim suitCard As Point 'New Point(0, 0)
    m_cycleDeck = 0

    ' Update options.
    UpdateStatus()

    ' Initialize cards.
    For i = 0 To 3
      For j = 0 To 12
        cards.SetValue(0, i, j)
      Next
    Next

    ' Initialize aces.
    For i = 0 To 3
      m_aceStackLengths(i) = 0
    Next

    ' Clear stacks.
    For i = 0 To 6
      For j = 0 To 4
        For k = 0 To 18
          m_stacks.SetValue(0, i, j, k)
        Next
      Next
    Next

    ' Clear deck.
    For i = 0 To 23
      m_deck.SetValue(0, 0, i)
      m_deck.SetValue(0, 1, i)
    Next

    ' Clear drop.
    For i = 0 To 23
      m_drop.SetValue(0, 0, i)
      m_drop.SetValue(0, 1, i)
    Next
    m_dropLength = 0

    ' Reset DragBox.
    DragBoxPictureBox_1.Size = New Size(1, 1)
    DragBoxPictureBox_1.Location = New Point(0, 0)

    For i = 0 To 6 ' Stack.
      Dim y = 0
      ' Darddepth up to stack #.
      For j = 0 To i - 1
        suitCard = NextCard(cards)
        ' Stack, suit, cardvalue, x, y, flipped, index.
        SetCard(i, suitCard.X, suitCard.Y, 0, y, 0, j)
        y += m_small
      Next
      ' Last card is flipped up.
      suitCard = NextCard(cards)
      ' Stack, suit, cardvalue, x, y, flipped, index=stack.
      SetCard(i, suitCard.X, suitCard.Y, 0, y, 1, i)
    Next

    ' Set deck.
    Dim kk = 0
    For i = 0 To 3
      For j = 0 To 12
        If CInt(cards.GetValue(i, j)) = 0 Then
          cards.SetValue(1, i, j) ' Set used flag.
          m_deck.SetValue(i, 0, kk)
          m_deck.SetValue(j, 1, kk)
          kk += 1
        End If
      Next
    Next
    m_deckLength = 24

    Shuffle()

    ' Clear or set variables.
    For i = 0 To 6
      m_stackLengths(i) = i + 1
    Next
    For i = 0 To 3
      m_aceStackLengths(i) = 0
    Next
    m_cycleDeck = 1
    Select Case m_settings.Scoring
      Case Scoring.Standard : m_score = 0
      Case Scoring.Vegas : m_score = -52
      Case Scoring.VegasCumulative : m_score += -52
    End Select

    ' Timer.
    m_time = 0
    GameTimer.Stop()
    UpdateStatus()

    ' Enable undo.
    UndoToolStripMenuItem.Enabled = False

    Invalidate(True)

  End Sub

  Private Function NextCard(cards As Array) As Point

    ' Get next random unused card in deck.

    Dim suit As CardSuit
    Dim cardValue As Integer

    Do
      ' Randomly select m_winParabola suit and card value.
      suit = CType(m_random.Next(4), CardSuit)
      cardValue = m_random.Next(13)
      ' Check to see if the card is already used.
      If CInt(cards.GetValue(suit, cardValue)) = 0 Then
        ' Not used, so we are done.
        Exit Do
      End If
    Loop

    'While CInt(cards.GetValue(suit, cardValue)) = 1 ' Card already used.
    '  suit = CType(m_random.Next(4), CardSuit)
    '  cardValue = m_random.Next(13)
    'End While

    cards.SetValue(1, suit, cardValue) ' Set used flag.

    'Dim suitCard As New Point(suit, cardValue)

    Return New Point(suit, cardValue) 'suitCard

  End Function

  Private Sub SetCard(stack As Integer, suit As Integer, cardValue As Integer, x As Integer, y As Integer, flipped As Integer, index As Integer)
    m_stacks.SetValue(suit, stack, 0, index) ' Suit.
    m_stacks.SetValue(cardValue, stack, 1, index) ' Card value.
    m_stacks.SetValue(x, stack, 2, index) ' X location.
    m_stacks.SetValue(y, stack, 3, index) ' Y location.
    m_stacks.SetValue(flipped, stack, 4, index) ' Flipped.
  End Sub

  Private Sub Shuffle()

    Dim temp = Array.CreateInstance(GetType(Int32), 2, 24)
    Dim templength = m_deckLength
    Dim j = 0

    ' Copy data to temp.
    For i = 0 To m_deckLength - 1
      temp.SetValue(CInt(m_deck.GetValue(0, i)), 0, i)
      temp.SetValue(CInt(m_deck.GetValue(1, i)), 1, i)
    Next

    For i = 0 To 23

      ' Get random index.
      Dim index = m_random.Next(templength)

      ' Copy data at that index to deck.
      m_deck.SetValue(CInt(temp.GetValue(0, index)), 0, j)
      m_deck.SetValue(CInt(temp.GetValue(1, index)), 1, j)

      ' Increment location in deck.
      j += 1

      ' Get last set in temp and move to index.
      temp.SetValue(CInt(temp.GetValue(0, templength - 1)), 0, index)
      temp.SetValue(CInt(temp.GetValue(1, templength - 1)), 1, index)

      ' Shorten temp.
      templength -= 1

    Next

  End Sub

#End Region

#Region "Paint/Draw Methods (includes drawing new cards)"

  Private Sub WindowSizeChanged(sender As Object, e As EventArgs) Handles MyBase.Resize

    Dim offset As Integer

    If m_win Then
      DragBoxPictureBox_1.Width = Width - 8
      DragBoxPictureBox_1.Height = Height - 54
    End If

    If Width > 593 Then
      offset = (Width - 8 - 7 * m_cardWidth) \ 8
      DeckToDealPictureBox.Location = New Point(offset, DeckToDealPictureBox.Location.Y)
      DropPanelPictureBox.Location = New Point(2 * offset + m_cardWidth, DropPanelPictureBox.Location.Y)
      AcePictureBox_0.Location = New Point(4 * offset + 3 * m_cardWidth, AcePictureBox_0.Location.Y)
      AcePictureBox_1.Location = New Point(5 * offset + 4 * m_cardWidth, AcePictureBox_1.Location.Y)
      AcePictureBox_2.Location = New Point(6 * offset + 5 * m_cardWidth, AcePictureBox_2.Location.Y)
      AcePictureBox_3.Location = New Point(7 * offset + 6 * m_cardWidth, AcePictureBox_3.Location.Y)

      StackPictureBox_0.Location = New Point(offset, StackPictureBox_0.Location.Y)
      StackPictureBox_1.Location = New Point(2 * offset + m_cardWidth, StackPictureBox_1.Location.Y)
      StackPictureBox_2.Location = New Point(3 * offset + 2 * m_cardWidth, StackPictureBox_2.Location.Y)
      StackPictureBox_3.Location = New Point(4 * offset + 3 * m_cardWidth, StackPictureBox_3.Location.Y)
      StackPictureBox_4.Location = New Point(5 * offset + 4 * m_cardWidth, StackPictureBox_4.Location.Y)
      StackPictureBox_5.Location = New Point(6 * offset + 5 * m_cardWidth, StackPictureBox_5.Location.Y)
      StackPictureBox_6.Location = New Point(7 * offset + 6 * m_cardWidth, StackPictureBox_6.Location.Y)
    Else
      offset = (593 - 8 - 7 * m_cardWidth) \ 8
      DeckToDealPictureBox.Location = New Point(offset, DeckToDealPictureBox.Location.Y)
      DropPanelPictureBox.Location = New Point(2 * offset + m_cardWidth, DropPanelPictureBox.Location.Y)
      AcePictureBox_0.Location = New Point(4 * offset + 3 * m_cardWidth, AcePictureBox_0.Location.Y)
      AcePictureBox_1.Location = New Point(5 * offset + 4 * m_cardWidth, AcePictureBox_1.Location.Y)
      AcePictureBox_2.Location = New Point(6 * offset + 5 * m_cardWidth, AcePictureBox_2.Location.Y)
      AcePictureBox_3.Location = New Point(7 * offset + 6 * m_cardWidth, AcePictureBox_3.Location.Y)

      StackPictureBox_0.Location = New Point(offset, StackPictureBox_0.Location.Y)
      StackPictureBox_1.Location = New Point(2 * offset + m_cardWidth, StackPictureBox_1.Location.Y)
      StackPictureBox_2.Location = New Point(3 * offset + 2 * m_cardWidth, StackPictureBox_2.Location.Y)
      StackPictureBox_3.Location = New Point(4 * offset + 3 * m_cardWidth, StackPictureBox_3.Location.Y)
      StackPictureBox_4.Location = New Point(5 * offset + 4 * m_cardWidth, StackPictureBox_4.Location.Y)
      StackPictureBox_5.Location = New Point(6 * offset + 5 * m_cardWidth, StackPictureBox_5.Location.Y)
      StackPictureBox_6.Location = New Point(7 * offset + 6 * m_cardWidth, StackPictureBox_6.Location.Y)
    End If

  End Sub

  Private Sub DoPaint(stack As Integer, sender As Object, e As PaintEventArgs)
    If sender Is Nothing Then
    End If

    'Dim i = 0
    Dim suit As Integer '= 0
    Dim cardvalue As Integer '= 0
    Dim x = 0
    Dim y = 0
    Dim flipped = 1
    Dim index As Integer '= 0
    Dim stackheight As Integer '= 0

    If stack < 7 Then
      index = m_stackLengths(stack)
    Else ' Aces.
      index = m_aceStackLengths(stack - 7)
    End If

    If stack < 7 Then
      If m_stackLengths(stack) <> 0 Then
        stackheight = CInt(m_stacks.GetValue(stack, 3, m_stackLengths(stack) - 1)) + m_cardHeight
      Else
        stackheight = m_cardHeight
      End If
      ' Set stack height.
      Select Case stack
        Case 0 : StackPictureBox_0.Height = stackheight
        Case 1 : StackPictureBox_1.Height = stackheight
        Case 2 : StackPictureBox_2.Height = stackheight
        Case 3 : StackPictureBox_3.Height = stackheight
        Case 4 : StackPictureBox_4.Height = stackheight
        Case 5 : StackPictureBox_5.Height = stackheight
        Case Else
          StackPictureBox_6.Height = stackheight
      End Select
    End If

    SuspendLayout()

    For i = 0 To index - 1

      If stack < 7 Then
        suit = CInt(m_stacks.GetValue(stack, 0, i))
        cardvalue = CInt(m_stacks.GetValue(stack, 1, i))
        y = CInt(m_stacks.GetValue(stack, 3, i))
        flipped = CInt(m_stacks.GetValue(stack, 4, i))
      Else ' Aces.
        suit = CInt(m_aceStacks.GetValue(stack - 7, 0, i))
        cardvalue = CInt(m_aceStacks.GetValue(stack - 7, 1, i))
      End If

      If flipped = 0 Then
        e.Graphics.DrawImage(CardBacksImageList.Images(m_settings.CardBack), x, y)
      ElseIf suit = 0 Then ' Spades.
        e.Graphics.DrawImage(SpadesImageList.Images(cardvalue), x, y)
      ElseIf suit = 1 Then ' Diamonds.
        e.Graphics.DrawImage(DiamondsImageList.Images(cardvalue), x, y)
      ElseIf suit = 2 Then ' Clubs.
        e.Graphics.DrawImage(ClubsImageList.Images(cardvalue), x, y)
      Else ' Hearts.
        e.Graphics.DrawImage(HeartsImageList.Images(cardvalue), x, y)
      End If

    Next

    ResumeLayout(False)

  End Sub

  Private Sub StackPictureBox_0_Paint(sender As Object, e As PaintEventArgs) Handles StackPictureBox_0.Paint
    DoPaint(0, sender, e)
  End Sub

  Private Sub StackPictureBox_1_Paint(sender As Object, e As PaintEventArgs) Handles StackPictureBox_1.Paint
    DoPaint(1, sender, e)
  End Sub

  Private Sub StackPictureBox_2_Paint(sender As Object, e As PaintEventArgs) Handles StackPictureBox_2.Paint
    DoPaint(2, sender, e)
  End Sub

  Private Sub StackPictureBox_3_Paint(sender As Object, e As PaintEventArgs) Handles StackPictureBox_3.Paint
    DoPaint(3, sender, e)
  End Sub

  Private Sub StackPictureBox_4_Paint(sender As Object, e As PaintEventArgs) Handles StackPictureBox_4.Paint
    DoPaint(4, sender, e)
  End Sub

  Private Sub StackPictureBox_5_Paint(sender As Object, e As PaintEventArgs) Handles StackPictureBox_5.Paint
    DoPaint(5, sender, e)
  End Sub

  Private Sub StackPictureBox_6_Paint(sender As Object, e As PaintEventArgs) Handles StackPictureBox_6.Paint
    DoPaint(6, sender, e)
  End Sub

  Private Sub AcePictureBox_0_Paint(sender As Object, e As PaintEventArgs) Handles AcePictureBox_0.Paint
    If m_aceStackLengths(0) = 0 Then
      e.Graphics.DrawImage(CardSlotsImageList.Images(2), 0, 0)
    Else
      DoPaint(7, sender, e)
    End If
  End Sub

  Private Sub AcePictureBox_1_Paint(sender As Object, e As PaintEventArgs) Handles AcePictureBox_1.Paint
    If m_aceStackLengths(1) = 0 Then
      e.Graphics.DrawImage(CardSlotsImageList.Images(2), 0, 0)
    Else
      DoPaint(8, sender, e)
    End If
  End Sub

  Private Sub AcePictureBox_2_Paint(sender As Object, e As PaintEventArgs) Handles AcePictureBox_2.Paint
    If m_aceStackLengths(2) = 0 Then
      e.Graphics.DrawImage(CardSlotsImageList.Images(2), 0, 0)
    Else
      DoPaint(9, sender, e)
    End If
  End Sub

  Private Sub AcePictureBox_3_Paint(sender As Object, e As PaintEventArgs) Handles AcePictureBox_3.Paint
    If m_aceStackLengths(3) = 0 Then
      e.Graphics.DrawImage(CardSlotsImageList.Images(2), 0, 0)
    Else
      DoPaint(10, sender, e)
    End If

  End Sub

  Private Sub DeckToDealPictureBox_Paint(sender As Object, e As PaintEventArgs) Handles DeckToDealPictureBox.Paint
    SuspendLayout()
    If m_deckLength < 0 OrElse (m_deckLength = 0 AndAlso m_dropLength = 0) Then
      ' Display empty deck image.
      e.Graphics.DrawImage(CardSlotsImageList.Images(0), 0, 0)
    Else
      ' Display card backs.
      e.Graphics.DrawImage(CardBacksImageList.Images(m_settings.CardBack), 0, 0)
      If m_deckLength > 10 Then
        e.Graphics.DrawImage(CardBacksImageList.Images(m_settings.CardBack), m_xShift, m_yShift)
      End If
      If m_deckLength > 20 Then
        e.Graphics.DrawImage(CardBacksImageList.Images(m_settings.CardBack), m_xShift + m_xShift, m_yShift + m_yShift)
      End If
    End If
    ResumeLayout(False)
  End Sub

  Private Sub DragBoxPictureBox_Paint(sender As Object, e As PaintEventArgs) Handles DragBoxPictureBox_1.Paint, DragBoxPictureBox_2.Paint, DragBoxPictureBox_3.Paint, DragBoxPictureBox_4.Paint
    If m_win Then
      ' Win effect.
      Win(sender, e)
    Else
      ' Draw images in DragBoxPictureBox.
      Dim x = 0
      SuspendLayout()
      For index = 0 To m_dragLength - 1
        Dim suit = CInt(m_drag.GetValue(0, index))
        Dim cardValue = CInt(m_drag.GetValue(1, index))
        Dim y = CInt(m_drag.GetValue(2, index))
        If Not m_settings.Outline Then
          Select Case suit
            Case 0 : e.Graphics.DrawImage(SpadesImageList.Images(cardValue), x, y) ' Spades
            Case 1 : e.Graphics.DrawImage(DiamondsImageList.Images(cardValue), x, y) ' Diamonds
            Case 2 : e.Graphics.DrawImage(ClubsImageList.Images(cardValue), x, y) ' Clubs
            Case Else ' Hearts
              e.Graphics.DrawImage(HeartsImageList.Images(cardValue), x, y)
          End Select
        Else
          ' Outline dragging.
        End If
      Next
      ResumeLayout(False)
    End If
  End Sub

  Private Sub DeckToDealPictureBox_MouseDown(sender As Object, e As MouseEventArgs) Handles DeckToDealPictureBox.MouseDown
    If e.Button = MouseButtons.Right Then
      MoveAllPossibleCardsUp()
      Return
    End If
    ' Check if actually over card.
    If m_deckLength < 11 AndAlso
       e.X < m_cardWidth AndAlso
       e.Y < m_cardHeight OrElse
       (m_deckLength > 10 AndAlso
        m_deckLength < 21 AndAlso
        e.X > m_xShift AndAlso
        e.X < m_xShift + m_cardWidth AndAlso
        e.Y > m_yShift AndAlso
        e.Y < m_yShift + m_cardHeight) OrElse
       (m_deckLength > 20 AndAlso
        e.X > 2 * m_xShift AndAlso
        e.X < 2 * m_xShift + m_cardWidth AndAlso
        e.Y > 2 * m_yShift AndAlso
        e.Y < 2 * m_yShift + m_cardHeight) Then
      m_drawing = True
      DropPanelPictureBox.Invalidate(New Region(New Rectangle(0, 0, DropPanelPictureBox.Width, DropPanelPictureBox.Height)), False)
      If m_deckLength = 1 OrElse m_deckLength = 11 OrElse m_deckLength = 21 Then
        DeckToDealPictureBox.Invalidate(New Region(New Rectangle(0, 0, DeckToDealPictureBox.Width, DeckToDealPictureBox.Height)), False)
      End If
    End If
  End Sub

  Private Sub DropPanelPictureBox_Paint(sender As Object, e As PaintEventArgs) Handles DropPanelPictureBox.Paint
    SuspendLayout()
    If m_drawing Then
      Dim limit = 1
      If m_deckLength > 0 Then
        If Not m_settings.DrawOne Then
          limit = 3
          If m_deckLength < 3 Then
            limit = m_deckLength
          End If
        End If
        ' Set undo information.
        m_undo.SetValue(limit, 0, 0)
        m_undoType = 0
        Dim undoCount = 0
        If m_dropLength > 0 Then
          If CInt(m_drop.GetValue(3, m_dropLength - 1)) <> 0 Then
            undoCount += 1
          End If
        End If
        If m_dropLength > 1 Then
          If CInt(m_drop.GetValue(3, m_dropLength - 2)) <> 0 Then
            undoCount += 1
          End If
        End If
        m_undo.SetValue(undoCount, 0, 1)

        For i = 0 To limit - 1

          ' Get card for card drop.
          Dim suit = CInt(m_deck.GetValue(0, m_deckLength - 1))
          Dim cardvalue = CInt(m_deck.GetValue(1, m_deckLength - 1))
          m_deckLength -= 1

          ' Add card to m_drop array.
          m_drop.SetValue(suit, 0, m_dropLength)
          m_drop.SetValue(cardvalue, 1, m_dropLength)
          m_drop.SetValue(i * m_xBigShift, 2, m_dropLength)
          m_drop.SetValue(i * m_yShift, 3, m_dropLength)
          m_dropLength += 1

          If m_dropLength > 3 AndAlso CInt(m_drop.GetValue(3, m_dropLength - 3)) <> 0 Then
            m_drop.SetValue(0, 2, m_dropLength - 3)
            m_drop.SetValue(0, 3, m_dropLength - 3)
          End If
          If m_dropLength > 4 AndAlso CInt(m_drop.GetValue(3, m_dropLength - 4)) <> 0 Then
            m_drop.SetValue(0, 2, m_dropLength - 4)
            m_drop.SetValue(0, 3, m_dropLength - 4)
          End If
        Next i
        ' Start timer if first move.
        If m_time = 0 AndAlso m_settings.TimedGame Then
          GameTimer.Start()
        End If
      End If
      If m_deckLength <= 0 Then ' Reset deck.
        If m_deckLength = -1 Then

          ' Set undo information.
          m_undoType = 6

          m_cycleDeck += 1
          m_deckLength = m_dropLength

          ' Move drop to deck.
          Dim k = 0
          For i = m_dropLength - 1 To 0 Step -1
            m_deck.SetValue(m_drop.GetValue(0, i), 0, k)
            m_deck.SetValue(m_drop.GetValue(1, i), 1, k)
            k += 1
          Next
          m_dropLength = 0

          ' Scoring.
          If m_settings.Scoring = Scoring.Standard AndAlso m_cycleDeck > 3 AndAlso Not m_settings.DrawOne Then
            m_score -= 20
          ElseIf m_settings.Scoring = Scoring.Standard AndAlso m_cycleDeck > 1 AndAlso m_settings.DrawOne Then
            m_score -= 100
          End If
          If m_settings.Scoring <> Scoring.None Then
            UpdateStatus()
          End If
          DeckToDealPictureBox.Invalidate(False)
        Else
          m_deckLength -= 1 ' Set to -1 to flip deck.
          DeckToDealPictureBox.Invalidate(False)
        End If
      End If
      m_drawing = False
      UndoToolStripMenuItem.Enabled = True
    End If
    ' Refresh cards.
    DealtDeck_Paint(sender, e)

    ResumeLayout(False)

  End Sub

  Private Sub DealtDeck_Paint(sender As Object, e As PaintEventArgs)

    ' Refresh cards.

    Dim x = 0
    Dim y = 0
    'Dim newSuit, newCardValue As Integer

    'TODO: Optimize this code so it only draws the last 3 (or less) cards - those that are visible.
    '      Right now, it's drawing every card over each other.

    For j = 0 To m_dropLength - 1

      If m_settings.DrawOne Then
        If j = 11 Then
          ' Draw one thickness.
          y += m_yShift
          x += m_xShift
        End If
        If j = 21 Then
          ' Draw one extra thickness.
          y += m_yShift
          x += m_xShift
        End If
      Else
        ' Draw three actual locations.
        x = CInt(m_drop.GetValue(2, j))
        y = CInt(m_drop.GetValue(3, j))
        'FIX: To clear the background if the last card is being displayed.
        If j = m_dropLength - 1 AndAlso x = 0 AndAlso y = 0 Then
          ' This is the last card on the pile, clear the background.
          e.Graphics.Clear(BackColor)
        End If
      End If

      Dim newSuit = CInt(m_drop.GetValue(0, j))
      Dim newCardValue = CInt(m_drop.GetValue(1, j))

      Select Case newSuit
        Case 0 : e.Graphics.DrawImage(SpadesImageList.Images(newCardValue), x, y) ' Spades
        Case 1 : e.Graphics.DrawImage(DiamondsImageList.Images(newCardValue), x, y) ' Diamonds
        Case 2 : e.Graphics.DrawImage(ClubsImageList.Images(newCardValue), x, y) ' Clubs
        Case Else ' Hearts
          e.Graphics.DrawImage(HeartsImageList.Images(newCardValue), x, y)
      End Select

    Next

  End Sub

  'Private Sub GameStatusBar_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles GameStatusBar.Layout
  '  UpdateStatus()
  'End Sub

  ' Have to owner draw the panel to get it to be red
  ' as panels don't have ForeColors (and StatusBars don't have right alignment).
  'Sub GameStatusBar_DrawItem(ByVal sender As Object, ByVal e As StatusBarDrawItemEventArgs) Handles GameStatusBar.DrawItem

  '  Const labelScore As String = "Score: "
  '  Const labelTime As String = "Time: "
  '  Const charSpace As Integer = 8

  '  Dim extraChar As Integer = 0
  '  Dim bar As StatusBar = CType(sender, StatusBar)
  '  Dim textColor As Color = bar.ForeColor
  '  Dim output As String = ""

  '  ' Score: xxx.
  '  Select Case m_settings.Scoring
  '    Case Scoring.None

  '    Case Scoring.Standard
  '      output &= m_score

  '    Case Scoring.Vegas, Scoring.VegasCumulative
  '      If m_score < 0 Then
  '        output &= "-$" & Math.Abs(m_score)
  '        textColor = Color.Red
  '        extraChar = 2
  '      Else
  '        output &= "$" & m_score
  '        extraChar = 1
  '      End If

  '    Case Else
  '      Debug.Assert(False)
  '  End Select

  '  If m_settings.Scoring <> Scoring.None Then

  '    ' Draw the score label.
  '    Dim format As New StringFormat
  '    format.Alignment = StringAlignment.Far
  '    format.LineAlignment = StringAlignment.Center
  '    Dim rect As Rectangle = bar.ClientRectangle
  '    If m_settings.TimedGame Then
  '      If m_score = 0 OrElse m_time = 0 Then
  '        rect.Width -= 64
  '      Else
  '        rect.Width -= 64 + (CInt(Math.Floor(Math.Log10(CDbl(m_score)))) * charSpace) + (CInt(Math.Floor(Math.Log10(CDbl(m_time)))) * charSpace)
  '      End If
  '    Else
  '      If m_score = 0 Then
  '        rect.Width -= 20
  '      Else
  '        rect.Width -= 20 + CInt(Math.Floor(Math.Log10(CDbl(m_score)))) * charSpace
  '      End If
  '    End If
  '    rect.Width -= extraChar * charSpace
  '    e.Graphics.DrawString(labelScore, bar.Font, Brushes.Black, RectangleF.op_Implicit(rect), format)

  '    ' Draw the score.
  '    Dim brush As Brush = New SolidBrush(textColor)
  '    Try
  '      format = New StringFormat
  '      format.Alignment = StringAlignment.Far
  '      format.LineAlignment = StringAlignment.Center
  '      rect = bar.ClientRectangle
  '      If m_settings.TimedGame Then
  '        If m_time = 0 Then
  '          rect.Width -= 49
  '        Else
  '          rect.Width -= 49 + CInt(Math.Floor(Math.Log10(CDbl(m_time)))) * charSpace
  '        End If
  '      Else
  '        rect.Width -= 8
  '      End If
  '      e.Graphics.DrawString(output, bar.Font, brush, RectangleF.op_Implicit(rect), format)
  '    Finally
  '      brush.Dispose()
  '    End Try

  '  End If

  '  ' Time: xxx.
  '  If m_settings.TimedGame Then
  '    Dim format As New StringFormat
  '    format.Alignment = StringAlignment.Far
  '    format.LineAlignment = StringAlignment.Center
  '    Dim rect As Rectangle = bar.ClientRectangle
  '    rect.Width -= 5
  '    e.Graphics.DrawString(labelTime & m_time.ToString, bar.Font, Brushes.Black, RectangleF.op_Implicit(rect), format)
  '  End If

  'End Sub

  Public Sub UpdateStatus()

    Const labelScore = "Score: "
    Const labelTime = "Time: "

    If m_settings IsNot Nothing Then

      If Not m_settings.Outline AndAlso Not DragBoxPictureBox_1.BackColor.Equals(Color.Transparent) Then
        DragBoxPictureBox_1.BackColor = Color.Transparent
      ElseIf m_settings.Outline AndAlso DragBoxPictureBox_1.BackColor.Equals(Color.Transparent) Then
        DragBoxPictureBox_1.BackColor = Color.Gray
      End If
      If m_settings.Scoring = Scoring.Standard AndAlso m_score < 0 Then
        m_score = 0
      End If
      GameStatusStrip.Visible = m_settings.ViewStatusBar

      Dim textColor = GameStatusStrip.ForeColor
      Dim output = ""

      ' Score: xxx.
      Select Case m_settings.Scoring
        Case Scoring.None

        Case Scoring.Standard
          output &= m_score

        Case Scoring.Vegas, Scoring.VegasCumulative
          If m_score < 0 Then
            output &= "-$" & Math.Abs(m_score)
            textColor = Color.Red
          Else
            output &= "$" & m_score
          End If

        Case Else
          Debug.Assert(False)
      End Select

      If m_settings.Scoring <> Scoring.None Then
        ScoreToolStripStatusLabel.Text = labelScore & output
        ScoreToolStripStatusLabel.ForeColor = textColor
      Else
        ScoreToolStripStatusLabel.Text = Nothing
      End If

      ' Time: xxx.
      If m_settings.TimedGame Then
        TimeToolStripStatusLabel.Text = $"{labelTime}{m_time}"
      Else
        TimeToolStripStatusLabel.Text = Nothing
      End If

    End If

  End Sub

  Private Sub InvalidateStack(stack As Integer)
    Select Case stack
      Case 0 : StackPictureBox_0.Invalidate(False)
      Case 1 : StackPictureBox_1.Invalidate(False)
      Case 2 : StackPictureBox_2.Invalidate(False)
      Case 3 : StackPictureBox_3.Invalidate(False)
      Case 4 : StackPictureBox_4.Invalidate(False)
      Case 5 : StackPictureBox_5.Invalidate(False)
      Case 6 : StackPictureBox_6.Invalidate(False)
      Case 7 : DropPanelPictureBox.Invalidate(False) ' Dealt cards.
      Case 8 : AcePictureBox_0.Invalidate(False)
      Case 9 : AcePictureBox_1.Invalidate(False)
      Case 10 : AcePictureBox_2.Invalidate(False)
      Case 11 : AcePictureBox_3.Invalidate(False)
    End Select

  End Sub

#End Region

#Region "Drag/Drop Methods"

  REM Private Sub GenericMouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GameStatusBar.MouseMove, DeckToDealPictureBox.MouseMove, MyBase.MouseMove
  Private Sub GenericMouseMove(sender As Object, e As MouseEventArgs) Handles DeckToDealPictureBox.MouseMove, MyBase.MouseMove

    If m_dragging Then

      Dim deltaX As Integer = DragBoxPictureBox_1.Location.X + (e.X - m_mouseX)
      Dim deltaY As Integer = DragBoxPictureBox_1.Location.Y + (e.Y - m_mouseY)

      ' Move DragBoxPictureBox to new delta'd mouse position.
      DragBoxPictureBox_1.Location = New Point(deltaX, deltaY)

      If m_settings.Outline Then
        deltaX = DragBoxPictureBox_2.Location.X + (e.X - m_mouseX)
        deltaY = DragBoxPictureBox_2.Location.Y + (e.Y - m_mouseY)
        DragBoxPictureBox_2.Location = New Point(deltaX, deltaY)

        deltaX = DragBoxPictureBox_3.Location.X + (e.X - m_mouseX)
        deltaY = DragBoxPictureBox_3.Location.Y + (e.Y - m_mouseY)
        DragBoxPictureBox_3.Location = New Point(deltaX, deltaY)

        deltaX = DragBoxPictureBox_4.Location.X + (e.X - m_mouseX)
        deltaY = DragBoxPictureBox_4.Location.Y + (e.Y - m_mouseY)
        DragBoxPictureBox_4.Location = New Point(deltaX, deltaY)

      End If
    End If

    m_mouseX = e.X
    m_mouseY = e.Y

  End Sub

  Private Sub DoMouseMove(sender As Object, e As MouseEventArgs, stack As Integer)
    If sender Is Nothing Then
    End If
    If m_dragging Then
      Dim deltaX As Integer = DragBoxPictureBox_1.Location.X + (e.X - m_mouseX)
      Dim deltaY As Integer = DragBoxPictureBox_1.Location.Y + (e.Y - m_mouseY)

      ' Move DragBoxPictureBox to new delta'd mouse position.
      DragBoxPictureBox_1.Location = New Point(deltaX, deltaY)

      If m_settings.Outline Then
        deltaX = DragBoxPictureBox_2.Location.X + (e.X - m_mouseX)
        deltaY = DragBoxPictureBox_2.Location.Y + (e.Y - m_mouseY)
        DragBoxPictureBox_2.Location = New Point(deltaX, deltaY)

        deltaX = DragBoxPictureBox_3.Location.X + (e.X - m_mouseX)
        deltaY = DragBoxPictureBox_3.Location.Y + (e.Y - m_mouseY)
        DragBoxPictureBox_3.Location = New Point(deltaX, deltaY)

        deltaX = DragBoxPictureBox_4.Location.X + (e.X - m_mouseX)
        deltaY = DragBoxPictureBox_4.Location.Y + (e.Y - m_mouseY)
        DragBoxPictureBox_4.Location = New Point(deltaX, deltaY)
      End If
    ElseIf e.Button = System.Windows.Forms.MouseButtons.Left Then
      ' Start timer if first move.
      If m_time = 0 AndAlso m_settings.TimedGame Then
        GameTimer.Start()
      End If
      ' Find which card was hit.
      If FindHit(stack) Then
        m_dragStack = stack
        m_dragging = True
        If stack > 6 OrElse CInt(m_stacks.GetValue(stack, 4, m_hitCard)) = 1 Then ' Flipped up or from DropPanelPictureBox or Aces.
          Dim x = 0
          Dim y = 0
          'Dim i = 0
          Dim locationX = 0
          Dim locationY = 0

          If stack < 7 Then
            x = CInt(m_stacks.GetValue(stack, 2, m_hitCard))
            y = CInt(m_stacks.GetValue(stack, 3, m_hitCard))
          ElseIf stack = 7 Then ' DropPanelPictureBox.
            x = CInt(m_drop.GetValue(2, m_hitCard))
            y = CInt(m_drop.GetValue(3, m_hitCard))
          End If

          If stack > 7 Then ' Aces.
            x = 0
            y = 0
          End If

          ' Get position of card for position of DragBoxPictureBox.
          If stack = 0 Then
            locationX = StackPictureBox_0.Location.X
            locationY = StackPictureBox_0.Location.Y
          ElseIf stack = 1 Then
            locationX = StackPictureBox_1.Location.X
            locationY = StackPictureBox_1.Location.Y
          ElseIf stack = 2 Then
            locationX = StackPictureBox_2.Location.X
            locationY = StackPictureBox_2.Location.Y
          ElseIf stack = 3 Then
            locationX = StackPictureBox_3.Location.X
            locationY = StackPictureBox_3.Location.Y
          ElseIf stack = 4 Then
            locationX = StackPictureBox_4.Location.X
            locationY = StackPictureBox_4.Location.Y
          ElseIf stack = 5 Then
            locationX = StackPictureBox_5.Location.X
            locationY = StackPictureBox_5.Location.Y
          ElseIf stack = 6 Then
            locationX = StackPictureBox_6.Location.X
            locationY = StackPictureBox_6.Location.Y
          ElseIf stack = 7 Then
            locationX = DropPanelPictureBox.Location.X
            locationY = DropPanelPictureBox.Location.Y
          ElseIf stack = 8 Then
            locationX = AcePictureBox_0.Location.X
            locationY = AcePictureBox_0.Location.Y
          ElseIf stack = 9 Then
            locationX = AcePictureBox_1.Location.X
            locationY = AcePictureBox_1.Location.Y
          ElseIf stack = 10 Then
            locationX = AcePictureBox_2.Location.X
            locationY = AcePictureBox_2.Location.Y
          ElseIf stack = 11 Then
            locationX = AcePictureBox_3.Location.X
            locationY = AcePictureBox_3.Location.Y
          End If

          ' Calculate height of DragBoxPictureBox.
          Dim dragboxheight As Integer
          If stack > 6 Then ' Aces and drop box.
            dragboxheight = m_cardHeight
          Else
            dragboxheight = m_cardHeight + m_large * (m_stackLengths(stack) - m_hitCard - 1)
          End If
          ' Copy information of dragging cards to drag array.
          Dim i = m_hitCard
          Dim j = 0
          If stack > 7 Then ' Aces.
            m_drag.SetValue(m_aceStacks.GetValue(stack - 8, 0, i), 0, j) ' Copy suit.
            m_drag.SetValue(m_aceStacks.GetValue(stack - 8, 1, i), 1, j) ' Copy card value.
            m_drag.SetValue(0, 2, j) ' Set y = 0.
            m_dragLength = 1 ' Set drag length to 1 card.
            If Not m_settings.Outline Then
              m_aceStackLengths((stack - 8)) -= 1 ' Make ace stack length 1 card smaller.
            End If
          ElseIf stack = 7 Then ' Drop box.
            m_drag.SetValue(m_drop.GetValue(0, i), 0, j) ' Copy suit.
            m_drag.SetValue(m_drop.GetValue(1, i), 1, j) ' Copy card value.
            m_drag.SetValue(0, 2, j) ' Set y = 0.
            m_dragLength = 1 ' Set drag length to 1 card.
            If Not m_settings.Outline Then
              m_dropLength -= 1 ' Make drop 1 card smaller.
            End If
          Else ' Stacks.
            While i < m_stackLengths(stack)
              m_drag.SetValue(m_stacks.GetValue(stack, 0, i), 0, j) ' Copy suit.
              m_drag.SetValue(m_stacks.GetValue(stack, 1, i), 1, j) ' Copy card value.
              m_drag.SetValue(CInt(m_stacks.GetValue(stack, 3, i)) - y, 2, j) ' Copy Y (adjusting for offset).
              i += 1
              j += 1
            End While

            ' Calculate length of drag array.
            m_dragLength = m_stackLengths(stack) - m_hitCard

            ' Shorten stack.
            If Not m_settings.Outline Then
              m_stackLengths(stack) = m_hitCard ' Note that the dragging cards are still in the stack.
            End If
          End If ' Modify DragBoxPictureBox for move.
          DragBoxPictureBox_1.Location = New Point(locationX + x, locationY + y)
          If Not m_settings.Outline Then
            DragBoxPictureBox_1.Size = New Size(m_cardWidth, dragboxheight)
          Else
            DragBoxPictureBox_1.Size = New Size(1, dragboxheight)
            DragBoxPictureBox_2.Location = New Point(locationX + x, locationY + y)
            DragBoxPictureBox_2.Size = New Size(m_cardWidth, 1)
            DragBoxPictureBox_3.Location = New Point(locationX + x + m_cardWidth, locationY + y)
            DragBoxPictureBox_3.Size = New Size(1, dragboxheight + 1)
            DragBoxPictureBox_4.Location = New Point(locationX + x, locationY + y + dragboxheight)
            DragBoxPictureBox_4.Size = New Size(m_cardWidth, 1)
          End If

          ' Refresh bug fix.
          m_dragStartX = locationX + x
          m_dragStartY = locationY + y

          Dim deltax As Integer = DragBoxPictureBox_1.Location.X + (e.X - m_mouseX)
          Dim deltay As Integer = DragBoxPictureBox_1.Location.Y + (e.Y - m_mouseY)

          ' Move DragBoxPictureBox to new delta'd mouse position.
          DragBoxPictureBox_1.Location = New Point(deltax, deltay)

          If m_settings.Outline Then
            deltax = DragBoxPictureBox_2.Location.X + (e.X - m_mouseX)
            deltay = DragBoxPictureBox_2.Location.Y + (e.Y - m_mouseY)
            DragBoxPictureBox_2.Location = New Point(deltax, deltay)

            deltax = DragBoxPictureBox_3.Location.X + (e.X - m_mouseX)
            deltay = DragBoxPictureBox_3.Location.Y + (e.Y - m_mouseY)
            DragBoxPictureBox_3.Location = New Point(deltax, deltay)

            deltax = DragBoxPictureBox_4.Location.X + (e.X - m_mouseX)
            deltay = DragBoxPictureBox_4.Location.Y + (e.Y - m_mouseY)
            DragBoxPictureBox_4.Location = New Point(deltax, deltay)
          End If

          Invalidate(New Rectangle(deltax, deltay, DragBoxPictureBox_1.Width, DragBoxPictureBox_1.Height), True)
          If m_settings.Outline Then
            Invalidate(True)
          End If
        Else ' Card flipped down.
          m_dragging = False
        End If
      End If
    End If

    ' Save new mouse position.
    m_mouseX = e.X
    m_mouseY = e.Y

  End Sub

  Private Function FindHit(stack As Integer) As Boolean

    'Dim i = 0
    Dim x, y As Integer
    Dim found As Boolean = False

    If stack > 7 Then ' Aces.
      If m_aceStackLengths((stack - 8)) <> 0 Then
        found = True
        m_hitCard = m_aceStackLengths((stack - 8)) - 1
      End If
    ElseIf stack = 7 Then ' DropBox.
      If m_dropLength <> 0 Then
        If Not m_settings.DrawOne Then
          x = CInt(m_drop.GetValue(2, m_dropLength - 1))
          y = CInt(m_drop.GetValue(3, m_dropLength - 1))
          If m_mouseX > x AndAlso m_mouseX < x + m_cardWidth Then
            If m_mouseY > y AndAlso m_mouseY < y + m_cardWidth Then
              m_hitCard = m_dropLength - 1
              found = True
            End If
          End If
          'i += 1
        Else ' Draw One.
          If m_mouseX < m_cardWidth Then
            m_hitCard = m_dropLength - 1
            found = True
          End If
        End If
      End If
    Else ' Stacks.
      Dim i = 0
      Dim offset As Integer
      While i < m_stackLengths(stack) AndAlso Not found
        y = CInt(m_stacks.GetValue(stack, 3, i))
        If i = m_stackLengths(stack) - 1 Then ' Flipped down.
          offset = y + m_cardHeight
        Else
          offset = CInt(m_stacks.GetValue(stack, 3, i + 1))
        End If
        If m_mouseY >= y AndAlso i = m_stackLengths(stack) - 1 AndAlso m_mouseY < offset OrElse (m_mouseY >= y AndAlso m_mouseY < offset) Then
          m_hitCard = i
          found = True
        End If
        i += 1
      End While
    End If

    Return found

  End Function

  Private Function HoverTest(i As Integer, left As Integer, right As Integer, top As Integer, bottom As Integer, thisStack As Integer) As Boolean

    Dim found As Boolean = False
    Dim cleft, cright, ctop, cbottom As Integer

    cleft = Controls(i).Location.X
    cright = cleft + m_cardWidth
    ctop = Controls(i).Location.Y
    cbottom = ctop + Controls(i).Height

    If cleft < left AndAlso cright > left OrElse (cleft > left AndAlso cleft < right) AndAlso thisStack <> Controls(i).TabIndex Then
      ' Horizontal match.
      If ctop < top AndAlso cbottom > top OrElse (ctop > top AndAlso ctop < bottom) Then
        ' Vertical match.
        found = True
      End If
    End If

    Return found

  End Function

  Private Sub StackPictureBox_0_MouseMove(sender As Object, e As MouseEventArgs) Handles StackPictureBox_0.MouseMove
    DoMouseMove(sender, e, 0)
  End Sub

  Private Sub StackPictureBox_1_MouseMove(sender As Object, e As MouseEventArgs) Handles StackPictureBox_1.MouseMove
    DoMouseMove(sender, e, 1)
  End Sub

  Private Sub StackPictureBox_2_MouseMove(sender As Object, e As MouseEventArgs) Handles StackPictureBox_2.MouseMove
    DoMouseMove(sender, e, 2)
  End Sub

  Private Sub StackPictureBox_3_MouseMove(sender As Object, e As MouseEventArgs) Handles StackPictureBox_3.MouseMove
    DoMouseMove(sender, e, 3)
  End Sub

  Private Sub StackPictureBox_4_MouseMove(sender As Object, e As MouseEventArgs) Handles StackPictureBox_4.MouseMove
    DoMouseMove(sender, e, 4)
  End Sub

  Private Sub StackPictureBox_5_MouseMove(sender As Object, e As MouseEventArgs) Handles StackPictureBox_5.MouseMove
    DoMouseMove(sender, e, 5)
  End Sub

  Private Sub StackPictureBox_6_MouseMove(sender As Object, e As MouseEventArgs) Handles StackPictureBox_6.MouseMove
    DoMouseMove(sender, e, 6)
  End Sub

  Private Sub DropPanelPictureBox_MouseMove(sender As Object, e As MouseEventArgs) Handles DropPanelPictureBox.MouseMove
    DoMouseMove(sender, e, 7)
  End Sub

  Private Sub AcePictureBox_0_MouseMove(sender As Object, e As MouseEventArgs) Handles AcePictureBox_0.MouseMove
    DoMouseMove(sender, e, 8)
  End Sub

  Private Sub AcePictureBox_1_MouseMove(sender As Object, e As MouseEventArgs) Handles AcePictureBox_1.MouseMove
    DoMouseMove(sender, e, 9)
  End Sub

  Private Sub AcePictureBox_2_MouseMove(sender As Object, e As MouseEventArgs) Handles AcePictureBox_2.MouseMove
    DoMouseMove(sender, e, 10)
  End Sub

  Private Sub AcePictureBox_3_MouseMove(sender As Object, e As MouseEventArgs) Handles AcePictureBox_3.MouseMove
    DoMouseMove(sender, e, 11)
  End Sub

  Sub MoveAllPossibleCardsUp()

    Dim working = True ' Are there more iterations to try?
    Dim cardsMoved = 0 ' Number of cards moved to ace stacks. Used for scoring.
    'Dim i As Integer = 0 ' Ace iteration variable.
    'Dim j As Integer = 0 ' Stack iteration variable.
    Dim aceSuit As Integer '= 0 ' Suits: spades=0, diamonds=1, clubs=2, hearts=3, undetermined=4.
    Dim aceCard As Integer = 0 ' Top ace card value.
    Dim currentSuit As Integer '= 0 ' Suits: spades=0, diamonds=1, clubs=2, hearts=3.
    Dim currentCard As Integer '= 0 ' Top stack card value.
    Dim currentFlipped As Integer '= 0 ' Whether card on stack is face up; no=0, yes=1.

    ' Find out what can be moved and move it.
    While working
      working = False
      For i = 0 To 3 ' Go through each ace.
        ' Get ace info.
        If CInt(m_aceStackLengths.GetValue(i)) <> 0 Then
          aceSuit = CInt(m_aceStacks.GetValue(i, 0, 0))
          aceCard = CInt(m_aceStackLengths.GetValue(i)) - 1
        Else
          aceSuit = 4
        End If
        If m_dropLength <> 0 Then ' Check for empty dealt card stack.
          ' Get drop info.
          currentSuit = CInt(m_drop.GetValue(0, m_dropLength - 1))
          currentCard = CInt(m_drop.GetValue(1, m_dropLength - 1))
          If currentSuit = aceSuit AndAlso currentCard = aceCard + 1 OrElse (aceSuit = 4 AndAlso currentCard = 0) Then ' Check dealt card.
            ' Move card.
            m_dropLength -= 1
            m_aceStackLengths(i) += 1
            m_aceStacks.SetValue(currentSuit, i, 0, m_aceStackLengths(i) - 1)
            m_aceStacks.SetValue(currentCard, i, 1, m_aceStackLengths(i) - 1)
            ' Set undo info.
            m_undoType = 4
            m_undo.SetValue(i, 4, 0)
            m_undo.SetValue(7, 4, 1)
            UndoToolStripMenuItem.Enabled = True
            ' Invalidate stacks.
            InvalidateStack((i + 8))
            InvalidateStack(7)
            ' Get new ace info.
            aceSuit = CInt(m_aceStacks.GetValue(i, 0, 0))
            aceCard = CInt(m_aceStackLengths.GetValue(i)) - 1
            cardsMoved += 1
            working = True
          End If
        End If
        For j = 0 To 6 ' Go through each stack.
          If m_stackLengths(j) <> 0 Then ' Check for empty stack.
            currentSuit = CInt(m_stacks.GetValue(j, 0, m_stackLengths(j) - 1))
            currentCard = CInt(m_stacks.GetValue(j, 1, m_stackLengths(j) - 1))
            currentFlipped = CInt(m_stacks.GetValue(j, 4, m_stackLengths(j) - 1))
            If currentSuit = aceSuit AndAlso currentCard = aceCard + 1 AndAlso currentFlipped = 1 OrElse (aceSuit = 4 AndAlso currentCard = 0 AndAlso currentFlipped = 1) Then ' See if stack is one more than ace in same suit.
              ' Move card.
              m_stackLengths(j) -= 1
              m_aceStackLengths(i) += 1
              m_aceStacks.SetValue(currentSuit, i, 0, m_aceStackLengths(i) - 1)
              m_aceStacks.SetValue(currentCard, i, 1, m_aceStackLengths(i) - 1)
              ' Set undo info.
              m_undoType = 4
              m_undo.SetValue(i, 4, 0)
              m_undo.SetValue(j, 4, 1)
              UndoToolStripMenuItem.Enabled = True
              ' Invalidate stacks.
              InvalidateStack((i + 8))
              InvalidateStack(j)
              ' Get new ace info.
              aceSuit = CInt(m_aceStacks.GetValue(i, 0, 0))
              aceCard = CInt(m_aceStackLengths.GetValue(i)) - 1
              cardsMoved += 1
              working = True
            End If
          End If
        Next
      Next
    End While

    ' Update scoring.
    If m_settings.Scoring = Scoring.Standard Then
      m_score += 10 * cardsMoved
      UpdateStatus()
    End If

  End Sub

  Private Sub HandleMouseUp(sender As Object, e As MouseEventArgs) _
    Handles AcePictureBox_1.MouseUp,
            AcePictureBox_2.MouseUp,
            AcePictureBox_0.MouseUp,
            AcePictureBox_3.MouseUp,
            StackPictureBox_4.MouseUp,
            StackPictureBox_6.MouseUp,
            StackPictureBox_5.MouseUp,
            StackPictureBox_1.MouseUp,
            StackPictureBox_0.MouseUp,
            StackPictureBox_2.MouseUp,
            StackPictureBox_3.MouseUp,
            DropPanelPictureBox.MouseUp,
            DragBoxPictureBox_1.MouseUp,
            DragBoxPictureBox_2.MouseUp,
            DragBoxPictureBox_3.MouseUp,
            DragBoxPictureBox_4.MouseUp,
            MyBase.MouseUp

    If Not m_dragging Then
      If e.Button = MouseButtons.Right Then
        MoveAllPossibleCardsUp()
      End If
      Return
    End If

    SuspendLayout()

    Dim left, right, top, bottom As Integer
    Dim found As Boolean = False
    'Dim i As Integer = 0

    ' Find DragBoxPictureBox_1 location.
    left = DragBoxPictureBox_1.Location.X
    right = left + m_cardWidth
    top = DragBoxPictureBox_1.Location.Y
    bottom = top + DragBoxPictureBox_1.Height

    ' Get drag stack so it's not same stack.
    Dim thisstack As Integer = 0
    If m_dragStack < 7 Then ' Stacks.
      thisstack = m_dragStack + 7
    ElseIf m_dragStack > 6 Then ' DropBox.
      thisstack = m_dragStack - 5
    End If
    ' Find which panel the DragBoxPictureBox_1 is over, first go through each panel.
    For i = 0 To (Controls.Count) - 1
      ' If over winParabola panel, drop if card match.
      If HoverTest(i, left, right, top, bottom, thisstack) AndAlso Not found Then
        ' If match, drop cards.
        If Controls(i).TabIndex > 6 AndAlso Controls(i).TabIndex < 14 Then ' Stacks.
          ' Set undo information.
          m_undoType = 1
          m_undo.SetValue(m_dragStack, 1, 0) ' Set drag from.
          m_undo.SetValue(Controls(i).TabIndex, 1, 1) ' Set drag to.
          m_undo.SetValue(m_dragLength, 1, 2) ' Set length.
          UndoToolStripMenuItem.Enabled = True
          ' New stack.
          'Dim stack As Integer '= 0
          Dim suit As Integer = 0
          Dim flipped As Integer = 0
          Dim cardvalue As Integer = 0
          Dim stack = Controls(i).TabIndex - 7
          If m_stackLengths(stack) <> 0 Then
            suit = CInt(m_stacks.GetValue(stack, 0, m_stackLengths(stack) - 1))
            cardvalue = CInt(m_stacks.GetValue(stack, 1, m_stackLengths(stack) - 1))
            flipped = CInt(m_stacks.GetValue(stack, 4, m_stackLengths(stack) - 1))
          End If

          ' Drag stack.
          Dim dSuit As Integer
          Dim dCardValue As Integer
          dSuit = CInt(m_drag.GetValue(0, 0))
          dCardValue = CInt(m_drag.GetValue(1, 0))

          ' Drop card.
          If dCardValue = 12 AndAlso m_stackLengths(stack) = 0 OrElse (flipped = 1 AndAlso suit Mod 2 <> dSuit Mod 2 AndAlso dCardValue = cardvalue - 1) Then ' Not flipped down, not same color, next card down.
            ' Drop cards on new stack.
            Dim k As Integer = 0
            Dim newY As Integer
            While k < m_dragLength
              dSuit = CInt(m_drag.GetValue(0, k))
              dCardValue = CInt(m_drag.GetValue(1, k))
              newY = 0
              If dCardValue <> 12 Then
                newY = CInt(m_stacks.GetValue(stack, 3, m_stackLengths(stack) - 1)) + m_large
              End If
              If k = 0 Then
                m_dragStartY = newY
              End If
              SetCard(stack, dSuit, dCardValue, 0, newY, 1, m_stackLengths(stack))
              m_stackLengths(stack) += 1
              found = True
              k += 1
            End While

            ' Scoring.
            If m_settings.Scoring = Scoring.Standard Then
              If m_dragStack = 7 Then
                m_score += 5
              ElseIf m_dragStack > 7 Then
                m_score -= 15
              End If
              UpdateStatus()
            End If

            Controls(i).Invalidate(New Region(New Rectangle(0, m_dragStartY, m_cardWidth, Controls(i).Height)), False)
          End If
        ElseIf Controls(i).TabIndex > 2 AndAlso Controls(i).TabIndex < 7 Then ' Ace drops.
          ' Set undo information.
          m_undoType = 1
          m_undo.SetValue(m_dragStack, 1, 0) ' Set drag from.
          m_undo.SetValue(Controls(i).TabIndex, 1, 1) ' Set drag to.
          m_undo.SetValue(1, 1, 2)
          UndoToolStripMenuItem.Enabled = True
          ' Drag stack.
          Dim dsuit, dcardvalue As Integer
          dsuit = CInt(m_drag.GetValue(0, 0))
          dcardvalue = CInt(m_drag.GetValue(1, 0))

          ' New stack.
          Dim suit As Integer = 0
          Dim cardvalue As Integer = 0
          'Dim stack As Integer = 0
          Dim stack = Controls(i).TabIndex - 3
          If m_aceStackLengths(stack) <> 0 Then
            suit = CInt(m_aceStacks.GetValue(stack, 0, m_aceStackLengths(stack) - 1))
            cardvalue = CInt(m_aceStacks.GetValue(stack, 1, m_aceStackLengths(stack) - 1))
          End If

          If m_aceStackLengths(stack) = 0 AndAlso dcardvalue = 0 OrElse (m_dragLength = 1 AndAlso dsuit = suit AndAlso dcardvalue = cardvalue + 1 AndAlso m_aceStackLengths(stack) <> 0) Then ' Next card or ace on new stack.
            ' Update data.
            m_aceStacks.SetValue(dsuit, stack, 0, m_aceStackLengths(stack))
            m_aceStacks.SetValue(dcardvalue, stack, 1, m_aceStackLengths(stack))
            m_aceStackLengths(stack) += 1

            ' Scoring.
            If m_settings.Scoring = Scoring.Standard Then
              m_score += 10
            ElseIf m_settings.Scoring = Scoring.Vegas OrElse m_settings.Scoring = Scoring.VegasCumulative Then
              m_score += 5
            End If
            If m_settings.Scoring <> Scoring.None Then
              UpdateStatus()
            End If
            If m_aceStackLengths(0) + m_aceStackLengths(1) + m_aceStackLengths(2) + m_aceStackLengths(3) = 52 Then ' Win.
              m_win = True
              UndoToolStripMenuItem.Enabled = False ' Disable undo.
              DragBoxPictureBox_1.Location = New Point(0, 0)
              DragBoxPictureBox_1.Height = 1
              DragBoxPictureBox_1.Width = 1
              DragBoxPictureBox_1.Invalidate(False)
            End If
            found = True

            ' Refresh stack.
            Controls(i).Invalidate(False)
          End If
        End If
      End If
    Next i
    If Not found AndAlso Not m_settings.Outline Then ' Not on dropable control or no card match, return to original.
      If m_dragStack > 7 Then ' Aces.
        m_aceStackLengths((m_dragStack - 8)) += 1
      ElseIf m_dragStack = 7 Then ' Drop panel.
        m_dropLength += 1
      Else
        m_stackLengths(m_dragStack) += m_dragLength
      End If
      ' Refresh stack.
      If m_dragStack < 7 Then
        Invalidate(New Rectangle(m_dragStartX, m_dragStartY, m_cardWidth, m_cardHeight + m_large * m_dragLength), True)
      ElseIf m_dragStack = 7 Then
        Invalidate(New Rectangle(m_dragStartX, m_dragStartY, m_cardWidth, m_cardHeight), True)
      Else
        Invalidate(New Rectangle(m_dragStartX, m_dragStartY, m_cardWidth, m_cardHeight), True)
      End If
    ElseIf found AndAlso m_settings.Outline Then ' Remove from first stack.
      If m_dragStack > 7 Then ' Aces.
        m_aceStackLengths((m_dragStack - 8)) -= 1
      ElseIf m_dragStack = 7 Then ' Drop panel.
        m_dropLength -= 1
      Else
        m_stackLengths(m_dragStack) -= m_dragLength
      End If
      ' Refresh stack.
      If m_dragStack < 7 Then
        InvalidateStack(m_dragStack)
      Else ' Aces or drop panel.
        Invalidate(True)
      End If
    End If
    ' Reset drag box.
    DragBoxPictureBox_1.Size = New Size(0, 0)
    DragBoxPictureBox_2.Size = New Size(0, 0)
    DragBoxPictureBox_3.Size = New Size(0, 0)
    DragBoxPictureBox_4.Size = New Size(0, 0)
    m_dragLength = 0 ' Note data is still in stack.
    m_dragging = False

    ResumeLayout(False)

  End Sub

#End Region

#Region "Menu Item Methods"

  ' Game

  Private Sub CheatWinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheatWinToolStripMenuItem.Click

    m_win = True

    For index As Integer = 0 To 12
      m_aceStacks.SetValue(0, 0, 0, index) ' Suit.
      m_aceStacks.SetValue(index, 0, 1, index) ' Card value.
      m_aceStacks.SetValue(1, 1, 0, index) ' Suit.
      m_aceStacks.SetValue(index, 1, 1, index) ' Card value.
      m_aceStacks.SetValue(2, 2, 0, index) ' Suit.
      m_aceStacks.SetValue(index, 2, 1, index) ' Card value.
      m_aceStacks.SetValue(3, 3, 0, index) ' Suit.
      m_aceStacks.SetValue(index, 3, 1, index) ' Card value.
    Next

    m_aceStackLengths(0) = 13
    m_aceStackLengths(1) = 13
    m_aceStackLengths(2) = 13
    m_aceStackLengths(3) = 13

    m_stackLengths(0) = 0
    m_stackLengths(1) = 0
    m_stackLengths(2) = 0
    m_stackLengths(3) = 0
    m_stackLengths(4) = 0
    m_stackLengths(5) = 0
    m_stackLengths(6) = 0

    m_dropLength = 0
    m_deckLength = 0

    DragBoxPictureBox_1.Location = New System.Drawing.Point(200, 200)
    DragBoxPictureBox_1.Height = 35
    DragBoxPictureBox_1.Width = 35

    DragBoxPictureBox_1.Invalidate(False)

  End Sub

  Private Sub DealToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DealToolStripMenuItem.Click
    ' Deal m_winParabola new game.
    Deal()
  End Sub

  Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click

    ' Undo 1 move.

    Select Case m_undoType
      Case 0 ' Deal m_winParabola card (or three if not deal one).

        m_drawing = False

        ' Put card(s) back.
        If m_settings.DrawOne Then
          If m_deckLength = -1 Then
            m_deckLength = 0
          End If
          m_deckLength += 1
          m_dropLength -= 1
        Else
          m_deckLength += CInt(m_undo.GetValue(0, 0))
          m_dropLength -= CInt(m_undo.GetValue(0, 0))
          If CInt(m_undo.GetValue(0, 1)) = 1 Then
            m_drop.SetValue(m_xBigShift, 2, m_dropLength - 1)
            m_drop.SetValue(m_yShift, 3, m_dropLength - 1)
          End If
          If CInt(m_undo.GetValue(0, 1)) = 2 Then
            m_drop.SetValue(m_xBigShift, 2, m_dropLength - 2)
            m_drop.SetValue(m_yShift, 3, m_dropLength - 2)
            m_drop.SetValue(2 * m_xBigShift, 2, m_dropLength - 1)
            m_drop.SetValue(2 * m_yShift, 3, m_dropLength - 1)
          End If
        End If

        ' Refresh stacks.
        If m_deckLength = 1 OrElse m_deckLength = 11 OrElse m_deckLength = 21 Then
          DeckToDealPictureBox.Invalidate(False)
        End If
        InvalidateStack(7) ' DropPanelPictureBox.

      Case 1 ' Drag drop.
        Dim dragfrom, dragto, dragquantity As Integer
        dragfrom = CInt(m_undo.GetValue(1, 0))
        dragto = CInt(m_undo.GetValue(1, 1))
        dragquantity = CInt(m_undo.GetValue(1, 2))
        ' Add cards to old stack.
        If dragfrom < 7 Then ' Stacks.
          ' Add back to stack.
          m_stackLengths(dragfrom) += dragquantity
          ' Scoring.
          If dragto < 7 AndAlso m_settings.Scoring = Scoring.Standard Then
            m_score -= 10
          ElseIf dragto < 7 AndAlso (m_settings.Scoring = Scoring.Vegas OrElse m_settings.Scoring = Scoring.VegasCumulative) Then
            m_score -= 5
          End If
        ElseIf dragfrom = 7 Then ' DropPanelPictureBox.
          m_dropLength += 1
          ' Scoring.
          If dragto < 7 AndAlso m_settings.Scoring = Scoring.Standard Then
            m_score -= 10
          ElseIf dragto < 7 AndAlso (m_settings.Scoring = Scoring.Vegas OrElse m_settings.Scoring = Scoring.VegasCumulative) Then
            m_score -= 5
          ElseIf dragto > 6 AndAlso m_settings.Scoring = Scoring.Standard Then
            m_score -= 5
          End If
        Else ' Ace stacks.
          m_aceStackLengths((dragfrom - 8)) += 1
          ' Scoring.
          If dragto > 6 AndAlso m_settings.Scoring = Scoring.Standard Then
            m_score += 15
          ElseIf dragto > 6 AndAlso (m_settings.Scoring = Scoring.Vegas OrElse m_settings.Scoring = Scoring.VegasCumulative) Then
            m_score += 5
          End If
        End If
        If m_settings.Scoring <> Scoring.None Then
          UpdateStatus()
        End If
        ' Remove cards from new stack.
        If dragto > 2 AndAlso dragto < 7 Then ' Aces.
          m_aceStackLengths((dragto - 3)) -= 1
        ElseIf dragto > 6 AndAlso dragto < 14 Then ' Stacks.
          m_stackLengths((dragto - 7)) -= dragquantity
        End If
        ' Refresh drag from.
        InvalidateStack(dragfrom)

        ' Refresh drag to.
        If dragto < 7 Then ' Aces.
          InvalidateStack((dragto + 5))
        ElseIf dragto > 6 Then ' Stacks.
          InvalidateStack((dragto - 7))
        End If

      Case 2 ' Extra...

      Case 3 ' Extra...

      Case 4 ' Drop 1 card on aces from stack or DropPanelPictureBox from double click.

        ' Take off aces.
        m_aceStackLengths(CInt(m_undo.GetValue(4, 0))) -= 1

        ' Scoring.
        If m_settings.Scoring = Scoring.Standard Then
          m_score -= 10
        ElseIf m_settings.Scoring = Scoring.Vegas OrElse m_settings.Scoring = Scoring.VegasCumulative Then
          m_score -= 5
        End If
        If m_settings.Scoring <> Scoring.None Then
          UpdateStatus()
        End If
        ' Replace card.
        If CInt(m_undo.GetValue(4, 1)) = 7 Then
          m_dropLength += 1
        Else
          m_stackLengths(CInt(m_undo.GetValue(4, 1))) += 1
        End If
        ' Refresh ace drop.
        If CInt(m_undo.GetValue(4, 0)) < 4 Then
          InvalidateStack((CInt(m_undo.GetValue(4, 0)) + 8))
        End If
        ' Refresh stack.
        If CInt(m_undo.GetValue(4, 1)) < 7 Then
          InvalidateStack(CInt(m_undo.GetValue(4, 1)))
        End If
        ' Refresh DropPanelPictureBox.
        InvalidateStack(7)

      Case 5 ' Flip m_winParabola card.

        ' Set flip bit.
        m_stacks.SetValue(0, CInt(m_undo.GetValue(5, 0)), 4, m_stackLengths(CInt(m_undo.GetValue(5, 0))) - 1)

        ' Scoring.
        If m_settings.Scoring = Scoring.Standard Then
          m_score -= 5
          UpdateStatus()
        End If

        ' Refresh stack.
        If CInt(m_undo.GetValue(5, 0)) < 7 Then
          InvalidateStack(CInt(m_undo.GetValue(5, 0)))
        End If

      Case 6 ' Flip over deck for drawing.
        m_cycleDeck -= 1
        m_dropLength = m_deckLength ' Reset m_dropLength to # of cards in deck.
        m_deckLength = -1  ' To show empty image.
        m_drawing = False

        ' Scoring.
        If m_settings.Scoring = Scoring.Standard AndAlso m_cycleDeck > 2 AndAlso Not m_settings.DrawOne Then
          m_score += 20
        ElseIf m_settings.Scoring = Scoring.Standard AndAlso m_cycleDeck > 0 AndAlso m_settings.DrawOne Then
          m_score += 100
        End If
        If m_settings.Scoring <> Scoring.None Then
          UpdateStatus()
        End If
        ' Refresh.
        DropPanelPictureBox.Invalidate(New System.Drawing.Region(New System.Drawing.Rectangle(0, 0, DropPanelPictureBox.Width, DropPanelPictureBox.Height)))
        DeckToDealPictureBox.Invalidate(False)

      Case Else

    End Select

    UndoToolStripMenuItem.Enabled = False

  End Sub

  Private Sub DeckToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeckToolStripMenuItem.Click

    ' Open deck dialog.

    Dim dialog As New CardBackDialog With {.Cardback = m_settings.CardBack}
    If dialog.ShowDialog(Me) = DialogResult.OK Then
      m_settings.CardBack = dialog.Cardback
      Deal()
    End If

  End Sub

  Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click

    ' Open options dialog box.

    Dim dialog = New OptionsDialog With {.Draw = If(m_settings.DrawOne, Draw.One, Draw.Three),
                                         .Scoring = m_settings.Scoring,
                                         .TimedGame = m_settings.TimedGame,
                                         .StatusBar = m_settings.ViewStatusBar,
                                         .OutlineDragging = m_settings.Outline}

    If dialog.ShowDialog(Me) = DialogResult.OK Then

      ' Update options.
      m_settings.DrawOne = dialog.Draw = Draw.One
      m_settings.Scoring = dialog.Scoring
      m_settings.TimedGame = dialog.TimedGame
      m_settings.Outline = dialog.OutlineDragging
      m_settings.ViewStatusBar = dialog.StatusBar

      ' Check if we need to redeal.
      If dialog.Redeal Then
        If dialog.Scoring <> m_settings.Scoring Then m_score = 0
        Deal()
      Else
        UpdateStatus()
      End If

    End If

  End Sub

  'Private Sub menuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItem1.Click
  '  MoveAllPossibleCardsUp()
  'End Sub

  Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
    ' Exit game.
    Close()
  End Sub

  ' Help

  Private Sub ContentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContentsToolStripMenuItem.Click
    'Refresh() ' To handle a slight refresh bug.
    Cursor = Cursors.WaitCursor
    Help.ShowHelp(Me, "sol.chm")
    Cursor = Cursors.Default
  End Sub

  Private Sub HowToUseoolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HowToUseToolStripMenuItem.Click
    'Refresh() ' To handle a slight refresh bug.
    Cursor = Cursors.WaitCursor
    Help.ShowHelp(Me, "nthelp.chm")
    Cursor = Cursors.Default
  End Sub

  Private Sub SearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchToolStripMenuItem.Click
    'Refresh() ' To handle a slight refresh bug.
    Cursor = Cursors.WaitCursor
    Help.ShowHelp(Me, "sol.chm", HelpNavigator.Index)
    Cursor = Cursors.Default
  End Sub

  Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
    Dim rslt = Win32.ShellAbout(Handle, "'Classic' Solitaire", "Developed by Cory Smith; portions by Christine Morin and Chris Sells.", Icon.Handle)
  End Sub

#End Region

#Region "Single Click Methods - Flip Cards"

  Private Sub DoClick(sender As Object, e As EventArgs, stack As Integer)
    If sender Is Nothing OrElse e Is Nothing Then
    End If
    If m_stackLengths(stack) <> 0 AndAlso CInt(m_stacks.GetValue(stack, 4, m_stackLengths(stack) - 1)) = 0 Then

      m_stacks.SetValue(1, stack, 4, m_stackLengths(stack) - 1)

      ' Scoring.
      If m_settings.Scoring = Scoring.Standard Then
        m_score += 5
        UpdateStatus()
      End If

      ' Set undo info - NOT IMPLEMENTED IN REAL SOLITAIRE.
      'm_undo.SetValue(stack, 5, 0)
      'm_undoType = 5
      'UndoToolStripMenuItem.Enabled = True
      UndoToolStripMenuItem.Enabled = False

      ' Refresh stack.
      InvalidateStack(stack)
    End If

  End Sub

  Private Sub StackPictureBox_0_Click(sender As Object, e As EventArgs) Handles StackPictureBox_0.Click
    DoClick(sender, e, 0)
  End Sub

  Private Sub StackPictureBox_1_Click(sender As Object, e As EventArgs) Handles StackPictureBox_1.Click
    DoClick(sender, e, 1)
  End Sub

  Private Sub StackPictureBox_2_Click(sender As Object, e As EventArgs) Handles StackPictureBox_2.Click
    DoClick(sender, e, 2)
  End Sub

  Private Sub StackPictureBox_3_Click(sender As Object, e As EventArgs) Handles StackPictureBox_3.Click
    DoClick(sender, e, 3)
  End Sub

  Private Sub StackPictureBox_4_Click(sender As Object, e As EventArgs) Handles StackPictureBox_4.Click
    DoClick(sender, e, 4)
  End Sub

  Private Sub StackPictureBox_5_Click(sender As Object, e As EventArgs) Handles StackPictureBox_5.Click
    DoClick(sender, e, 5)
  End Sub

  Private Sub StackPictureBox_6_Click(sender As Object, e As EventArgs) Handles StackPictureBox_6.Click
    DoClick(sender, e, 6)
  End Sub

#End Region

#Region "DoubleClick Methods - Send to ace drops."

  Private Sub DoDoubleClick(sender As Object, e As EventArgs, stack As Integer)
    If sender Is Nothing OrElse e Is Nothing Then
    End If
    Dim x, y, xRight, yBottom, suit, cardValue, i As Integer
    If stack = 7 AndAlso m_dropLength <> 0 OrElse (stack <> 7 AndAlso m_stackLengths(stack) <> 0) Then ' Stack not empty.
      If stack = 7 Then ' Drop box.
        suit = CInt(m_drop.GetValue(0, m_dropLength - 1))
        cardValue = CInt(m_drop.GetValue(1, m_dropLength - 1))
        x = CInt(m_drop.GetValue(2, m_dropLength - 1))
        y = CInt(m_drop.GetValue(3, m_dropLength - 1))
      Else ' Stacks.
        suit = CInt(m_stacks.GetValue(stack, 0, m_stackLengths(stack) - 1))
        cardValue = CInt(m_stacks.GetValue(stack, 1, m_stackLengths(stack) - 1))
        x = CInt(m_stacks.GetValue(stack, 2, m_stackLengths(stack) - 1))
        y = CInt(m_stacks.GetValue(stack, 3, m_stackLengths(stack) - 1))
      End If

      xRight = x + m_cardWidth
      yBottom = y + m_cardHeight

      ' Check if mouse is over last card.
      If m_mouseX > x AndAlso m_mouseX < xRight AndAlso m_mouseY > y AndAlso m_mouseY < yBottom Then
        If cardValue = 0 Then ' Ace.
          i = 0
          While i < 4
            If m_aceStackLengths(i) = 0 Then
              m_aceStacks.SetValue(suit, i, 0, 0) ' Set suit.
              m_aceStacks.SetValue(cardValue, i, 1, 0) ' Set card value.
              m_aceStackLengths(i) += 1 ' Increment ace stack length.
              If stack = 7 Then ' Drop box.
                m_dropLength -= 1
              Else ' Stacks
                m_stackLengths(stack) -= 1
              End If
              ' Scoring.
              If m_settings.Scoring = Scoring.Standard Then
                m_score += 10
              ElseIf m_settings.Scoring = Scoring.Vegas OrElse m_settings.Scoring = Scoring.VegasCumulative Then
                m_score += 5
              End If
              If m_settings.Scoring <> Scoring.None Then
                UpdateStatus()
              End If
              ' Refresh stack.
              InvalidateStack(stack)

              ' Refresh aces.
              InvalidateStack((i + 8))

              ' Set undo info.
              m_undoType = 4
              m_undo.SetValue(i, 4, 0)
              m_undo.SetValue(stack, 4, 1)
              UndoToolStripMenuItem.Enabled = True

              i = 3 ' Exit loop.
            End If
            i += 1
          End While
        Else ' Non-Ace.
          i = 0
          While i < 4
            If m_aceStackLengths(i) <> 0 AndAlso CType(m_aceStacks.GetValue(i, 0, m_aceStackLengths(i) - 1), System.Int32) = suit AndAlso CType(m_aceStacks.GetValue(i, 1, m_aceStackLengths(i) - 1), System.Int32) = cardValue - 1 Then
              m_aceStacks.SetValue(suit, i, 0, m_aceStackLengths(i)) ' Set suit.
              m_aceStacks.SetValue(cardValue, i, 1, m_aceStackLengths(i)) ' Set card value.
              m_aceStackLengths(i) += 1 ' Increment ace stack length.
              If stack = 7 Then ' Drop box.
                m_dropLength -= 1
              Else ' Stacks.
                m_stackLengths(stack) -= 1
              End If
              ' Refresh stack.
              InvalidateStack(stack)

              ' Refresh aces.
              InvalidateStack((i + 8))

              ' Scoring.
              If m_settings.Scoring = Scoring.Standard Then
                m_score += 10
              ElseIf m_settings.Scoring = Scoring.Vegas OrElse m_settings.Scoring = Scoring.VegasCumulative Then
                m_score += 5
              End If
              If m_settings.Scoring <> Scoring.None Then
                UpdateStatus()
              End If
              ' Set undo info.
              m_undoType = 4
              m_undo.SetValue(i, 4, 0)
              m_undo.SetValue(stack, 4, 1)
              UndoToolStripMenuItem.Enabled = True

              If m_aceStackLengths(0) + m_aceStackLengths(1) + m_aceStackLengths(2) + m_aceStackLengths(3) = 52 Then ' Win.
                m_win = True
                UndoToolStripMenuItem.Enabled = False ' Disable undo.
                DragBoxPictureBox_1.Location = New Point(0, 0)
                DragBoxPictureBox_1.Height = 1
                DragBoxPictureBox_1.Width = 1
                DragBoxPictureBox_1.Invalidate(False)
              End If

              i = 3
            End If
            i += 1
          End While
        End If
      End If
    Else ' Stack is empty.
      ' Do nothing.
    End If

  End Sub

  Private Sub StackPictureBox_0_DoubleClick(sender As Object, e As EventArgs) Handles StackPictureBox_0.DoubleClick
    DoDoubleClick(sender, e, 0)
  End Sub

  Private Sub StackPictureBox_1_DoubleClick(sender As Object, e As EventArgs) Handles StackPictureBox_1.DoubleClick
    DoDoubleClick(sender, e, 1)
  End Sub

  Private Sub StackPictureBox_2_DoubleClick(sender As Object, e As EventArgs) Handles StackPictureBox_2.DoubleClick
    DoDoubleClick(sender, e, 2)
  End Sub

  Private Sub StackPictureBox_3_DoubleClick(sender As Object, e As EventArgs) Handles StackPictureBox_3.DoubleClick
    DoDoubleClick(sender, e, 3)
  End Sub

  Private Sub StackPictureBox_4_DoubleClick(sender As Object, e As EventArgs) Handles StackPictureBox_4.DoubleClick
    DoDoubleClick(sender, e, 4)
  End Sub

  Private Sub StackPictureBox_5_DoubleClick(sender As Object, e As EventArgs) Handles StackPictureBox_5.DoubleClick
    DoDoubleClick(sender, e, 5)
  End Sub

  Private Sub StackPictureBox_6_DoubleClick(sender As Object, e As EventArgs) Handles StackPictureBox_6.DoubleClick
    DoDoubleClick(sender, e, 6)
  End Sub

  Private Sub DropPanelPictureBox_DoubleClick(sender As Object, e As EventArgs) Handles DropPanelPictureBox.DoubleClick
    DoDoubleClick(sender, e, 7)
  End Sub

#End Region

#Region "Win Effect"

  Private Sub Win(sender As Object, e As PaintEventArgs)

    If Not m_win2 Then

      ' Set up drawing surface. Using drag box.
      DragBoxPictureBox_1.Location = New Point(0, MenuStrip1.Top + MenuStrip1.Height)
      DragBoxPictureBox_1.Width = ClientSize.Width
      DragBoxPictureBox_1.Height = ClientSize.Height - (MenuStrip1.Height + GameStatusStrip.Height) ' 54

      ' Get ace stack locations
      m_aceLocation.SetValue(AcePictureBox_0.Location.X, 0, 0)
      m_aceLocation.SetValue(AcePictureBox_0.Location.Y, 1, 0)
      m_aceLocation.SetValue(AcePictureBox_1.Location.X, 0, 1)
      m_aceLocation.SetValue(AcePictureBox_1.Location.Y, 1, 1)
      m_aceLocation.SetValue(AcePictureBox_2.Location.X, 0, 2)
      m_aceLocation.SetValue(AcePictureBox_2.Location.Y, 1, 2)
      m_aceLocation.SetValue(AcePictureBox_3.Location.X, 0, 3)
      m_aceLocation.SetValue(AcePictureBox_3.Location.Y, 1, 3)

      ' Get suits.
      m_suit(0) = CInt(m_aceStacks.GetValue(0, 0, 0))
      m_suit(1) = CInt(m_aceStacks.GetValue(1, 0, 0))
      m_suit(2) = CInt(m_aceStacks.GetValue(2, 0, 0))
      m_suit(3) = CInt(m_aceStacks.GetValue(3, 0, 0))

      m_win2 = True
      m_winX = CInt(m_aceLocation.GetValue(0, 0))
      m_winY = CInt(m_aceLocation.GetValue(1, 0))
      m_winStack = 0
      m_winCard = 12

    End If

    ' Fix transparency issue.
    e.Graphics.FillRegion(New SolidBrush(Color.White), New Region(New Rectangle(m_winX, m_winY, m_cardWidth, m_cardHeight)))

    If m_suit(m_winStack) = 0 Then ' Spades.
      e.Graphics.DrawImage(SpadesImageList.Images(m_winCard), m_winX, m_winY)
    ElseIf m_suit(m_winStack) = 1 Then ' Diamonds.
      e.Graphics.DrawImage(DiamondsImageList.Images(m_winCard), m_winX, m_winY)
    ElseIf m_suit(m_winStack) = 2 Then ' Clubs.
      e.Graphics.DrawImage(ClubsImageList.Images(m_winCard), m_winX, m_winY)
    Else ' Hearts.
      e.Graphics.DrawImage(HeartsImageList.Images(m_winCard), m_winX, m_winY)
    End If

    WinAlgorithm()

    ' Check if at end of window.
    If m_winY + m_cardHeight >= DragBoxPictureBox_1.Height Then 'do new m_bounce
      m_bounce = True
    End If
    If m_winX + m_cardWidth <= 0 OrElse m_winX >= DragBoxPictureBox_1.Width Then
      If m_winStack = 3 Then
        ' Done with win effect.
        If m_winCard = 0 Then
          m_win = False
          ' Clear drag box.
          DragBoxPictureBox_1.Invalidate()
          ' Reset variables.
          m_win2 = False
          ' Play again dialog.
          Dim dialog As New DealAgainDialog
          If dialog.ShowDialog(Me) = DialogResult.Yes Then
            Deal()
          End If
        Else
          m_winCard -= 1
          m_winStack = 0
          m_newWinStack = True
          m_winX = CInt(m_aceLocation.GetValue(0, m_winStack))
          m_winY = CInt(m_aceLocation.GetValue(1, m_winStack))
        End If
      ElseIf m_winCard <> 0 OrElse m_winStack <> 3 Then
        m_winStack += 1
        m_newWinStack = True
        m_winX = CInt(m_aceLocation.GetValue(0, m_winStack))
        m_winY = CInt(m_aceLocation.GetValue(1, m_winStack))
      End If
    End If
    DragBoxPictureBox_1.Invalidate(New Region(New Rectangle(m_winX, m_winY, m_cardWidth, m_cardHeight)), False)
    Threading.Thread.Sleep(7)
  End Sub

  Private Sub WinAlgorithm()

    Dim z As Single '= 0

    ' NOTE: CARTESIAN COORDINATES ARE REVERSE POSITIVE AND NEGATIVE: 
    '       to correct, won't make parabola negative.
    ' PARABOLA FORMULA: m_winY = m_winParabola * (m_winX - m_xVertex) ^ 2 + m_yVertex.
    If m_newWinStack Then ' On new stack, must reset variables.

      m_newWinStack = False

      ' Pick m_winParabola vertex somewhere in window above 
      m_xVertex = m_random.Next(0, 2)
      If m_xVertex = 0 Then
        m_xVertex = m_winX + 24
      Else
        m_xVertex = m_winX - 24
      End If
      m_yVertex = m_random.Next(-m_cardWidth, m_winY)

      ' Set m_xMovement (pixels, random), compensate for non-true randomness.
      Dim i = m_random.Next(0, 4)
      If i = 0 Then
        m_xMovement = m_random.Next(-3, -1)
      ElseIf i = 1 Then
        m_xMovement = m_random.Next(2, 4)
      ElseIf i = 2 Then
        i = m_random.Next(0, 2)
        If i = 0 Then
          m_xMovement = m_random.Next(-4, 0)
        Else
          m_xMovement = m_random.Next(-4, -1)
        End If
      Else
        i = m_random.Next(0, 2)
        If i = 0 Then
          m_xMovement = m_random.Next(1, 5)
        Else
          m_xMovement = m_random.Next(2, 5)
        End If
      End If

      ' Set m_yMultiplier (4/3, 5/4, or 6/5; float).
      Dim ymultrand = m_random.Next(3, 7)
      m_yMultiplier = (ymultrand + 1.0!) / ymultrand

      z = m_winX - m_xVertex
      m_winParabola = (m_winY - m_yVertex) / (z * z)

    ElseIf m_bounce Then ' Same stack bounce.

      'Dim newyvertex As Integer = 0
      Dim newxvertex = 0

      ' Get new m_yVertex, shift for inverted cartesian coordinates, take percentage, and revert.
      Dim newyvertex = CInt(Math.Ceiling(CSng(DragBoxPictureBox_1.Height) - (CInt(CSng(DragBoxPictureBox_1.Height) - CSng(m_yVertex))) \ CInt(m_yMultiplier)))

      ' formula: solve for m_xVertex (note - will get 2 answers keep greater answer if horizontal
      '          move is positive, else keep lesser answer).
      '
      ' Set old = new:
      '   m_winParabola(m_winX - m_xVertex)(m_winX - m_xVertex) + m_yVertex = m_winParabola(m_winX - newxvertex)(m_winX - newxvertex) + newyvertex.
      ' solve for newxvertex:
      '   newxvertex = -Sqrt((m_winParabola(m_winX - m_xVertex)(m_winX - m_xVertex) + m_yVertex - newyvertex) / m_winParabola) + m_winX.
      z = (m_winParabola * (m_winX - m_xVertex) * (m_winX - m_xVertex) + m_yVertex - newyvertex) / m_winParabola
      If z < 0 OrElse DragBoxPictureBox_1.Height - newyvertex - m_cardHeight < 6 Then ' Too m_small of m_winParabola m_bounce, reduce to 4/5ths of m_winParabola bounce.
        newyvertex = m_yVertex + 4
        z = (m_winParabola * CSng(m_winX - m_xVertex) * (m_winX - m_xVertex) + m_yVertex - newyvertex) / m_winParabola
      End If

      Dim xint1 = CInt(-Math.Sqrt(z) + m_winX)
      Dim xint2 = CInt(Math.Sqrt(z) + m_winX)

      If m_xMovement > 0 AndAlso xint1 > xint2 Then
        newxvertex = xint1
      ElseIf m_xMovement > 0 AndAlso xint2 > xint1 Then
        newxvertex = xint2
      ElseIf m_xMovement < 0 AndAlso xint1 < xint2 Then
        newxvertex = xint1
      ElseIf m_xMovement < 0 AndAlso xint2 < xint1 Then
        newxvertex = xint2
      ElseIf m_xMovement < 0 AndAlso xint1 = xint2 AndAlso xint1 < m_xVertex Then
        newxvertex = xint1
      ElseIf m_xMovement > 0 AndAlso xint1 = xint2 AndAlso xint1 > m_xVertex Then
        newxvertex = xint1
      Else
        If m_xMovement < 0 Then
          newxvertex = m_xVertex - 1
        End If
        If m_xMovement > 0 Then
          newxvertex = m_xVertex - 1
        End If
      End If
      ' Update vertices.
      m_xVertex = newxvertex
      m_yVertex = newyvertex
    End If
    ' Update m_winX.
    m_winX += m_xMovement

    ' Update m_winY.
    z = m_winX - m_xVertex
    If m_winParabola * z * z + m_yVertex > m_winY AndAlso m_bounce Then
      m_winY = m_winY 'BUG: Shouldn't get here.
    Else
      m_winY = CInt(m_winParabola * z * z + m_yVertex)
    End If
    m_bounce = False

  End Sub

#End Region

End Class