namespace Mowrer.FSWebster.CLI

open System
open System.Globalization
open System.IO
open CsvHelper
open CsvHelper.Configuration
open Mowrer.FSWebster.Shared

module Main =
    [<EntryPoint>]
    let main argv =
        let testFileName = "test.csv"
        
        use reader = new StreamReader(testFileName)
        use csvReader = new CsvReader(reader, CultureInfo.InvariantCulture)
        
        let records = csvReader.GetRecords<InputEntry>() |> Seq.toArray
                
        let populations = [| for record in records do yield record.Population |]
        
        let seatDistribution = Webster.apportionSeats populations 8
                
        records |> Seq.iteri (fun idx entry -> printfn $"%s{entry.Name} with %d{entry.Population} folks gets %d{seatDistribution[idx]} seats")
        0
        
        