namespace myMathModelsTests

open myMathModels
open System
open Xunit
module myMathematicalTests =
    
   
    [<Fact>]
    let ``My subtractor Model throws an exception`` () =
        let Input1 = 5m
        let Input2 = 4m
        let expectedOutput = 1m
        let actualoutput = myMathModel.subractor (Input1,Input2)
        Assert.Equal(expectedOutput,actualoutput)

    [<Fact>]
    let ``My addition  Model throws an exception`` () =
        let x = -4m
        let y = 4m
        let expectedoutput = 0m
        let actualOutput = myMathModel.additions (x,y)
        Assert.Equal(expectedoutput,actualOutput)
    
    [<Fact>]
    let ``Multiplicative Model throws an exception`` () =
        let a = 4m
        let b = 8m
        let expectedoutput = 32m
        let actualOutput = myMathModel.Multiplier (a,b)
        Assert.Equal(expectedoutput,actualOutput)
     
     
    [<Fact>]
    let ``mean model test`` () =
        let inputNumbers = [1m;4m;5m;6m]
        let ourOutput = 5.33m
        let actualOutput = CentralTendency.Ourmean inputNumbers
        Assert.Equal(ourOutput,Math.Round (actualOutput,2))

    [<Fact>]
    let ``Variance model test`` () =
        let inputNumbers = [1m;4m;5m;6m]
        let ourOutput = 5.28m
        let actualOutput = CentralTendency.VarCalc inputNumbers
        Assert.Equal(ourOutput,Math.Round (actualOutput,2))

    [<Fact>]
    let ``Tracking error model test`` () =
        let inputportfolio = [1m;4m;5m;6m]
        let inputbenchmark = [2m;4m;5m;8m]
        let outPut = 1.118m
        let actualOutput = CentralTendency.trackingError (inputportfolio, inputbenchmark)
        Assert.Equal(outPut,Math.Round (actualOutput,3))
    
    
    [<Fact>]
    let ``Geometric mean model test`` () =
        let inputportfolio = [1m;4m;5m;6m]
        let outPut = 4.527m
        let actualOutput = CentralTendency.geometricMean inputportfolio
        Assert.Equal(outPut,Math.Round (actualOutput,3))

    [<Fact>]
    let ``mean model test with the match function`` () =
        let input = [1m;4m;5m;6m]
        let outPut = 5.33m
        let actualOutput = CentralTendency.mean(input) None
        Assert.Equal(outPut,Math.Round( actualOutput,2))
    