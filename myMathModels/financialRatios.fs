namespace myMathModels

open System
open myMathModel


type financialRatios ()= 
    member this.GrossSales (input1:list<decimal>)=
     let grossSalesOutput =
        match input1 with 
        |[] -> raise(ArgumentException("input a value"))
        |a -> List.sum a
     grossSalesOutput

    member this.NetSalesInputs (returns:list<decimal>, allowances:list<decimal>,discounts:list<decimal>)=
           let totalReturns = List.sum returns
           let totalAllowance = List.sum allowances
           let totalDiscounts = List.sum discounts
           totalAllowance + totalDiscounts + totalReturns

    member this.GrossProfit ( inputGrossSales:decimal, inputNetSales:decimal) =
        inputNetSales- inputGrossSales
        
    
   
     member this.grossmargin(grossprofit: decimal, sales: list<decimal>) =
            if List.isEmpty sales then 
                raise(ArgumentException("input a value"))
            else
            grossprofit/List.sum sales
            
    
    //let netSales (returns : list<decimal>, allowances: list<decimal>, discounts: list<decimal>)=
    //   let totalReturns = List.sum returns
    //   let totalAllowances = List.sum allowances
    //   let totalDiscounts = List.sum discounts
    //   grossSales - (totalReturns + totalAllowances + totalDiscounts)


    //let costOfGoodsSold (startingInventory:decimal, purchases: list<decimal>, closingInventory:decimal) =
    //    if startingInventory = 0m or closingInventory = 0m then
    //        raise(ArgumentException("input a valid input"))
    //    elif List.isEmpty purchases then
    //        raise(ArgumentException("input a value"))
    //    else 
    //    let sumPurchases =  List.sum purchases
    //    ((startingInventory + sumPurchases) - closingInventory)

    //let revenue (unitsSold:decimal, costPerUnit:decimal) =
    //    if unitsSold = 0m or costPerUnit = 0m then
    //        raise(ArgumentException("The value cannot be  zero"))
    //    else
    //    (unitsSold * costPerUnit)
