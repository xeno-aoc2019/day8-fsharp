module day8_fsharp.InputService

open System.IO

let chars_from_file (filename : string) = 
   use sr = new StreamReader(filename)
   while not sr.EndOfStream do
        let c = sr.Read()
        printfn "%i" (c - int('0'))
   "hello"
