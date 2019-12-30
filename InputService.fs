module day8_fsharp.InputService

open System.IO

let chars_from_file (filename: string) =
    let zero = int('0')
    seq {
        use sr = new StreamReader(filename)
        while not sr.EndOfStream do
            let c = sr.Read()
            yield c - int('0')
    } |> Seq.filter (fun (c:int) -> (c >= 0) && c <= 2 ) 
