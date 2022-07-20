namespace myMathModels
open System


module myMathModel = 

//This function takes in a decimal input and subtracts from another decimal input.
    let subractor (inputOne: decimal, inputTwo : decimal ) =
        
        if inputOne + inputTwo <= 0m then 
            raise (ArgumentException ("invalid input one"))
        else
        inputOne - inputTwo
            
        
    let additions (a : decimal, b: decimal) =
        if a + b < 0m then  
           raise (ArgumentException (" input a positive value"))
        else
        a + b 
        
          
    let Multiplier (x : decimal, y: decimal) =
         if x * y <= 0m then
          raise (ArgumentException (" input positive values"))
         else
         x * y
          
    let DifferenceOfThreeNumbers a b c =
        if (a - b - c) <= 0m then
          raise (ArgumentException ("input positive values"))
        else
        a - b - c

module CentralTendency =
//powe function
    let pow(a:decimal, d:decimal) = decimal (float a ** float d)
    let squareRoot(a:decimal) = pow(a ,0.5m)
    let square a:decimal = a * a

    let Ourmean(numbers: list<decimal>) =
        if numbers.Length = 0 then
          raise(ArgumentException("Invalid input - no values provided"))
        elif numbers.Length > 30 then
              List.sum numbers/(decimal numbers.Length)
              
        else
              List.sum numbers/(decimal numbers.Length - 1m)
         

    let weightedMean (numbers: list<decimal>)(weights) =

        if numbers.Length = 0 then
            raise(ArgumentException("Invalid input - no values provided"))
        else
            match numbers.Length > 30 with
                | true -> List.average numbers
                | false ->
                match numbers.Length = 1 with  
                    | true ->  List.average numbers 
                    | false ->
                    match numbers.Length <=30 with
                        | true -> let sum = numbers |> List.sum in sum/(decimal numbers.Length - 1m)
                        | false ->  numbers |> List.average

    let squares (a:decimal,b:decimal)= decimal(float a * float b)

    let mean (numbers: list<decimal>) (weight:decimal option) =
       let meanOutput =
        match numbers with

        |[] -> raise(ArgumentException("Invalid input - no values provided"))

        | numbers when List.length numbers > 30 ->  List.average numbers 

        | numbers -> (List.sum numbers)/decimal(numbers.Length - 1) 
      
       let results =
         match weight with
         |Some weight -> weight *meanOutput
         |None -> meanOutput
       results



        //match numbers.Length > 30 with
        //| true -> List.average numbers
        //| false ->
        //match numbers.Length = 1 with
        //| true -> List.sum numbers
        //| false ->
        //let sum = numbers |> List.sum in sum/(decimal numbers.Length - 1m)


    let VarCalc (inputNumbers: list<decimal>) =
        let deviationfrommean = List.sumBy (fun x -> pow((x - Ourmean (inputNumbers) ),2m)) inputNumbers
        deviationfrommean/decimal inputNumbers.Length
        
           
    let StdCalc (nums: list<decimal>) = 
        pow(VarCalc(nums),0.5m)  
      
    
    let kurtosis (inputNums: list<decimal>) =
        let mean = List.average inputNums
        let forthMoment = List.sumBy (fun x->  pow((x-mean),4m)) inputNums
        let secondMoment = List.sumBy (fun x->  pow((x-mean),2m)) inputNums
        (forthMoment/pow(secondMoment,2m))

    let covariance (input1: list<decimal>, input2: list<decimal>) =
        let sumofdeviations = (List.zip input1 input2 |> List.sumBy(fun (x,y) -> (x - Ourmean (input1)) * (y - Ourmean (input2))))
        sumofdeviations/ decimal(List.zip input1 input2 |> List.length)
        


    let   trimmedMean (inputPrices: list<decimal>, percentBound: decimal) =
        let priceLength = inputPrices.Length
        let sortedPrices = List.sort inputPrices
        let NtoBeRemoved = int(percentBound * decimal (priceLength))
        let trimmedList  = sortedPrices[NtoBeRemoved..(priceLength - NtoBeRemoved)]
        ((List.sum trimmedList)/ decimal (trimmedList.Length))


    let trackingError (portfolioReturns: list<decimal>,benchmarkReturns: list<decimal> ) =
        
          let outPut =
            if List.isEmpty portfolioReturns || List.isEmpty benchmarkReturns then 
                raise(ArgumentException (" input a value"))
            elif
                (List.length portfolioReturns   <> List.length benchmarkReturns) then 
                raise(ArgumentException (" both lists have to be equal"))
            else
       
            let ourN = List.zip portfolioReturns benchmarkReturns
            let sumOfDeviations = (List.sumBy (fun (x,y)-> pow((x-y),2m)) ourN)/decimal ourN.Length 
            let res = pow(sumOfDeviations,0.5m)
            res
          outPut


    let geometricMean (inputData: list<decimal>) = 
       if List.isEmpty inputData then 
        raise (ArgumentException("input a valid value"))
       elif 
        inputData |> List.contains 100m then
        raise (ArgumentException("The value input is not relevant"))
        else
        let addition = List.map (fun x -> x + 1m) inputData
        let multiplier = List.reduce(fun i n -> i * n )addition
        pow(multiplier, (1m /decimal(List.length inputData)))
    
    
    //let trackingError2 (portfolioReturns: list<decimal>,benchmarkReturns: list<decimal> ) =
        
    //        if List.isEmpty portfolioReturns then 
    //            printfn "empty list"
    //        elif 
    //            List.isEmpty benchmarkReturns  then
    //            printfn "empty list"
    //        elif
    //            (List.length portfolioReturns   <> List.length benchmarkReturns) 
    //            then    
    //            printfn "unequal list"
            
       
    //        let ourN = List.zip portfolioReturns benchmarkReturns
    //        let sumOfDeviations = (List.sumBy (fun (x,y)-> pow((x-y),2m)) ourN)/decimal ourN.Length 
    //        let res = pow(sumOfDeviations,0.5m)
    //        res 
   
    












    //type myCalculations(input1 : decimal, input2 : decimal) = 
      //member this.checks =       
        //  if input1 = 0m then 
          //    raise(ArgumentException("Please input value 1"))
            //else input1
          //if input2 = 0M then
            //raise(ArgumentException ("Please input value 2"))
          //else input2
     // member this.Subtraction  =
       //      input1 - input2

      //member this.Addition = 
        //    input1 + input2

      //member this.Multiplication (input3 :decimal) =
        //     (input1 * input2)/input3
