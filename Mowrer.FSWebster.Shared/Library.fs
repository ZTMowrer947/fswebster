namespace Mowrer.FSWebster.Shared

module Webster =
    let quotient population seats = float population / float (2 * seats + 1)
    
    let apportionSeats populations totalSeats =
        let seatAllocations = Array.zeroCreate (populations |> Seq.length)
        let quotients = Array.map2 quotient populations seatAllocations
        
        seq { 1..totalSeats } |> Seq.iter (fun _ ->
            let maxQuotient = quotients |> Array.max
            let maxIdx = quotients |> Array.findIndex (fun quotient -> quotient = maxQuotient)
            
            seatAllocations[maxIdx] <- seatAllocations[maxIdx] + 1
            quotients[maxIdx] <- quotient populations[maxIdx] seatAllocations[maxIdx]
            )
        
        seatAllocations
        