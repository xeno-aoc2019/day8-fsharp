module day8_fsharp.Layer

type public Layer =
    { pixels: seq<int> }

let rec splitn (list: seq<'a>, psize: int) =
    match Seq.length list with
    | x when x < psize -> []
    | x when x = psize -> [ list ]
    | _ ->
        let head = (Seq.take 150) list
        let tail = (Seq.skip 150) list
        head :: (splitn (tail, psize))



let countPixels layer value =
    let matchingpixels:seq<int> = Seq.filter (fun v -> v = value) layer.pixels
    Seq.length matchingpixels

