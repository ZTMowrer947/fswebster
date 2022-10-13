namespace Mowrer.FSWebster.CLI

open CsvHelper.Configuration

type OutputEntry() =
    inherit InputEntry()
    
    member val Seats = 0 with get, set
    
type OutputEntryMap() as self =
    inherit ClassMap<OutputEntry>()
    do
        self.Map(fun e -> e.Name).Index(0) |> ignore
        self.Map(fun e -> e.Population).Index(1) |> ignore
        self.Map(fun e -> e.Seats).Index(2) |> ignore
        