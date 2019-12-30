module day8_fsharp.Layer

type public Layer =
    { pixels: array<int> }

let rec splitn (list: seq<'a>, psize: int) =
    match Seq.length list with
    | x when x < psize -> []
    | x when x = psize -> [ list ]
    | _ ->
        let head = (Seq.take psize) list
        let tail = (Seq.skip psize) list
        head :: (splitn (tail, psize))

let countPixels layer value =
    let matchingpixels: seq<int> = Seq.filter (fun v -> v = value) layer.pixels
    Seq.length matchingpixels

let printLayer (layer: Layer) =
    let lines = splitn (layer.pixels, 25)
    for line in lines do
        for pixel in line do
            let character =
                match pixel with
                | 0 -> " "
                | 1 -> "█"
                | 2 -> "-"
                | n -> "?"
            printf "%s" character
        printfn "%s" ""
