module Mowrer.FSWebster.Testing

open Mowrer.FSWebster.Shared
open NUnit.Framework

[<SetUp>]
let Setup () =
    ()

[<Test>]
let ApportionSeatsYieldsProperSeatDistributions () =
    let populations = [|
        100_000 // A
        80_000 // B
        30_000 // C
        20_000 // D
    |]
    let expectedSeats = [| 3; 3; 1; 1 |]
    let seats = Webster.apportionSeats populations 8
    
    Assert.That(seats, Is.EquivalentTo expectedSeats)