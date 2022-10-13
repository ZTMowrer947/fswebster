namespace Mowrer.FSWebster.CLI

open System.Globalization
open System.IO
open CsvHelper
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
                
        let outputRecords = records |> Array.mapi (fun index record ->
                let outRecord = OutputEntry()
                outRecord.Name <- record.Name
                outRecord.Population <- record.Population
                outRecord.Seats <- seatDistribution[index]
        
                outRecord)
        
        use writer = new StreamWriter("out.csv")
        use csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture)
        
        csvWriter.Context.RegisterClassMap<OutputEntryMap>() |> ignore
        csvWriter.WriteRecords outputRecords
        
        0
        
        