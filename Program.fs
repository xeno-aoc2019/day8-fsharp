// Learn more about F# at http://fsharp.org

open System
open System.Diagnostics
open System.Timers
open day8_fsharp
open day8_fsharp.InputService
open day8_fsharp.Layer
open day8_fsharp.LayerService




[<EntryPoint>]
let main argv =
    let pixels = InputService.chars_from_file @"../../../input.txt"
    let x = new Stopwatch()
    let layers = toLayers pixels
    x.Start()
    printfn "Read %A#" pixels
    printfn "Size: %i" (Seq.length pixels)
    printfn "Split: %A" layers
    let zeroPixelsForFirstLayer = countPixels layers.Head 0
    let layerTask1 = findLeastZeroLayer (zeroPixelsForFirstLayer, layers.Head, layers.Tail)
    let ones = countPixels layerTask1 1
    let twos = countPixels layerTask1 2
    let answer = ones * twos 
    printfn "Task 1: layer = %A answer=%i" layerTask1 answer 
    x.Stop()
    printfn "%O" x.Elapsed
    0 // return an integer exit code
