module day8_fsharp.LayerService

open Layer
open day8_fsharp
open day8_fsharp


let public toLayers (pixels: seq<int>) =
    let layerPixels = splitn (pixels, 150)
    let layers: seq<Layer> = Seq.map (fun pixels -> { pixels = Array.ofSeq pixels }) layerPixels
    List.ofSeq layers

let rec public findLeastZeroLayer (zeroCount: int, bestlayer: Layer, layers: list<Layer>) =
    if List.isEmpty layers then
        bestlayer
    else
        let head :: tail = layers
        let newCount: int = countPixels head 0
        if newCount < zeroCount then findLeastZeroLayer (newCount, head, tail)
        else findLeastZeroLayer (zeroCount, bestlayer, tail)

let rec pixelValue (i: int) (layers: list<Layer>) =
    match layers with
    | [] -> 2
    | head :: tail ->
        let headPixel = head.pixels.[i]
        if headPixel = 2 then pixelValue i tail
        else headPixel
