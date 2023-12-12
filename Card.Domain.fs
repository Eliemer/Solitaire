namespace Solitaire.Domain

module Cards =
    open Microsoft.FSharp.Reflection

    [<NoComparison>]
    [<Struct>]
    type Color =
        | Red
        | Black

    [<Struct>]
    [<NoComparison>]
    type Suit =
        | Clubs
        | Diamonds
        | Hearts
        | Spades

        member this.Color =
            match this with
            | Spades
            | Clubs -> Black
            | Diamonds
            | Hearts -> Red

    [<Struct>]
    type Rank =
        | Ace
        | Two
        | Three
        | Four
        | Five
        | Six
        | Seven
        | Eight
        | Nine
        | Ten
        | Jack
        | Queen
        | King

    type Card = { Suit : Suit; Rank : Rank }

    type Spot =
        // Where all 52 cards come from
        | Deck
        // The play area piles
        | Pile
        // Where the suits are built up
        | Foundation of Suit

    // The first element of the list is the top of the stack
    type Stack = { Cards : Card list; Spot : Spot }

    let StandardDeck =
        {
            Stack.Spot = Deck
            Cards =
                [
                    { Suit = Clubs; Rank = Ace }
                    { Suit = Diamonds; Rank = Ace }
                    { Suit = Hearts; Rank = Ace }
                    { Suit = Spades; Rank = Ace }
                    { Suit = Clubs; Rank = Two }
                    { Suit = Diamonds; Rank = Two }
                    { Suit = Hearts; Rank = Two }
                    { Suit = Spades; Rank = Two }
                    { Suit = Clubs; Rank = Three }
                    { Suit = Diamonds; Rank = Three }
                    { Suit = Hearts; Rank = Three }
                    { Suit = Spades; Rank = Three }
                    { Suit = Clubs; Rank = Four }
                    { Suit = Diamonds; Rank = Four }
                    { Suit = Hearts; Rank = Four }
                    { Suit = Spades; Rank = Four }
                    { Suit = Clubs; Rank = Five }
                    { Suit = Diamonds; Rank = Five }
                    { Suit = Hearts; Rank = Five }
                    { Suit = Spades; Rank = Five }
                    { Suit = Clubs; Rank = Six }
                    { Suit = Diamonds; Rank = Six }
                    { Suit = Hearts; Rank = Six }
                    { Suit = Spades; Rank = Six }
                    { Suit = Clubs; Rank = Seven }
                    { Suit = Diamonds; Rank = Seven }
                    { Suit = Hearts; Rank = Seven }
                    { Suit = Spades; Rank = Seven }
                    { Suit = Clubs; Rank = Eight }
                    { Suit = Diamonds; Rank = Eight }
                    { Suit = Hearts; Rank = Eight }
                    { Suit = Spades; Rank = Eight }
                    { Suit = Clubs; Rank = Nine }
                    { Suit = Diamonds; Rank = Nine }
                    { Suit = Hearts; Rank = Nine }
                    { Suit = Spades; Rank = Nine }
                    { Suit = Clubs; Rank = Ten }
                    { Suit = Diamonds; Rank = Ten }
                    { Suit = Hearts; Rank = Ten }
                    { Suit = Spades; Rank = Ten }
                    { Suit = Clubs; Rank = Jack }
                    { Suit = Diamonds; Rank = Jack }
                    { Suit = Hearts; Rank = Jack }
                    { Suit = Spades; Rank = Jack }
                    { Suit = Clubs; Rank = Queen }
                    { Suit = Diamonds; Rank = Queen }
                    { Suit = Hearts; Rank = Queen }
                    { Suit = Spades; Rank = Queen }
                    { Suit = Clubs; Rank = King }
                    { Suit = Diamonds; Rank = King }
                    { Suit = Hearts; Rank = King }
                    { Suit = Spades; Rank = King }
                ]
        }
