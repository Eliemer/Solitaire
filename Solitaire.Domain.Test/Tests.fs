module Tests

open Xunit
open FsCheck
open FsCheck.Xunit

open Solitaire.Domain.Card
open Solitaire.Domain.Logic

[<Fact>]
let ``My test`` () = Assert.True(true)

[<Properties>]
module StackTests =

    [<Property>]
    let ``Adding an Ace to a Pile increases the height of the stack``
        (card : Card)
        =
        let pile : Stack = Pile { Cards = [] }

        Stack.addToStack card pile
        |> Result.map (fun pileAfter ->
            let cards = (Stack.getCards pile)
            let cardsAfter = (Stack.getCards pileAfter)
            cards.Length + 1 = cardsAfter.Length)
        |> Result.isOk
        |> Assert.True
