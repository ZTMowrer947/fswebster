namespace Mowrer.FSWebster.CLI

open Mowrer.FSWebster.Shared

module Main =
    let names = [| "A"; "B"; "C"; "D" |]
    let pops = [| 100000; 80000; 30000; 20000 |]
    let seatDistribution = Webster.apportionSeats pops 8
    
    let entries = Array.map2 (fun pop name -> { Name = name; Population = pop }) pops names
    
    entries |> Array.iteri (fun idx entry -> printfn $"%s{entry.Name} with %d{entry.Population} folks gets %d{seatDistribution[idx]} seats")
    
    