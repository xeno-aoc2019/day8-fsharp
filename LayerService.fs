module day8_fsharp.LayerService

open Layer
open day8_fsharp
open day8_fsharp


let public toLayers (pixels: seq<int>) =
    let layerPixels = splitn (pixels, 150)
    let layers: seq<Layer> = Seq.map (fun pixels -> { pixels = pixels }) layerPixels
    List.ofSeq layers
    
let rec public findLeastZeroLayer (zeroCount: int, bestlayer: Layer, layers: list<Layer>) =
    if List.isEmpty layers then
        bestlayer
    else
        let  head :: tail = layers
        let newCount:int = countPixels head 0
        if newCount < zeroCount then findLeastZeroLayer (newCount, head, tail)
        else findLeastZeroLayer (zeroCount, bestlayer, tail)
