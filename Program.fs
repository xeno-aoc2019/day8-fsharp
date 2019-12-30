// Learn more about F# at http://fsharp.org

open System
open System.Diagnostics
open System.Timers
open day8_fsharp
open day8_fsharp.InputService
open day8_fsharp.Layer
open day8_fsharp.LayerService

let solve1 (layers: list<Layer>) =
    let zeroPixelsForFirstLayer = countPixels layers.Head 0
    let layerTask1 = findLeastZeroLayer (zeroPixelsForFirstLayer, layers.Head, layers.Tail)
    let ones = countPixels layerTask1 1
    let twos = countPixels layerTask1 2
    let answer = ones * twos
    answer

let solve2 (layers: list<Layer>) =
    let sumLayer =
        { pixels =
              [| for n in 0 .. 149 -> pixelValue n layers |] }
    printLayer sumLayer

[<EntryPoint>]
let main argv =
    let pixels = InputService.chars_from_file @"../../../input.txt"
    let x = new Stopwatch()
    let layers = toLayers pixels
    x.Start()
    // printfn "Read %A#" pixels
    // printfn "Size: %i" (Seq.length pixels)
    // printfn "Split: %A" layers

    let answer1 = solve1 layers
    printfn "Task 1: answer=%i" answer1
    x.Stop()
    printfn "%O" x.Elapsed
    solve2 layers 
    0 // return an integer exit code
