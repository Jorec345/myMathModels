namespace myMathModelsTests

open myMathModels
open System
open Xunit

module ratios = 
    [<Fact>]
    let ``Gross sales tests`` () =
            let input = [20m;30m;40m;60m;70m]
            let output = 220m
            let actualOutput = financialRatios().GrossSales input
            Assert.Equal(output, actualOutput)

    [<Fact>]
    let ``Net sales variables tests`` () =
            let input1= [20m;30m;40m;60m;70m]
            let input2 = [30m;40m;60m]
            let input3 = [20m;40m;30m]
            let output = 440m
            let actualOutput = financialRatios().NetSalesInputs (input1,input2,input3)
            Assert.Equal(output, actualOutput)
    
    [<Fact>]
    let ``Gross Profit validation`` () =
            let input1= [20m;30m;40m;60m;70m]
            let input2 = [30m;40m;60m;25m;12m]
            let input3 = [20m;30m;40m;60m;25m]
            let input4 = [40m;60m;25m;20m;30m]
            let output = 297m
            let grossSales = financialRatios().GrossSales input1
            let netSales = financialRatios().NetSalesInputs (input2,input3,input4)
            let actual = netSales - grossSales
            Assert.Equal(output, actual)
    //[<Fact>]
    //    let ``My COGS model is doing the right thing`` () =
    //        let openingInventory = 500m
    //        let Purchases = [20m;5m;40m;45m]
    //        let closingInventory = 200m
    //        let expectedOutput = 410m
    //        let actualoutput = financialRatios.costOfGoodsSold (openingInventory,Purchases,closingInventory)
    //        Assert.Equal(expectedOutput, actualoutput)
    //[<Fact>]
    //        let ``My revenue model test`` () =
    //            let numberOfUnits = 500m
    //            let costOfUnits = 20
    //            let expectedOutput = 10000m
    //            let actualoutput = financialRatios.revenue (numberOfUnits,costOfUnits)
    //            Assert.Equal(expectedOutput, actualoutput)


