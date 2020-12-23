using System;
using System.Collections.Generic;
using System.Linq;
using PlayMath.API.Dtos;
using PlayMath.API.Dtos.AlgebraDtos;
using PlayMath.API.MathHelperClasses;

namespace PlayMath.API.MathEngine
{
    public class Algebra : IAlgebra
    {
        public List<QuadraticSolutionDto> Qudratic(int a = 1, int b = 1, int c = 0, int d = 0)
        {
            List<QuadraticSolutionDto> solution =  new List<QuadraticSolutionDto>();

            c =  c - d;
            if(d != 0)
            solution.Add(new QuadraticSolutionDto()
                {
                    SolutionLine = AssitUtilities.PlusAndKill(true, false, a) + "x^2" 
                                    + AssitUtilities.PlusAndKill(false, false, b) + "x"
                                    + AssitUtilities.PlusAndKill(false, true, c) + " = 0"
                                    .ToString(),
                    Description = "xxxxxxxx"
                });

            d = a * c;

            var factors = d.Divisors();  

            var pairFactor = AssitUtilities.MidTermFactorPair(factors, b, d);

            if(pairFactor[0] != 0 && pairFactor[1] != 0)
            { 
                solution.Add(new QuadraticSolutionDto()
                {
                    SolutionLine = AssitUtilities.PlusAndKill(true, false, a) + "x^2" 
                                    + AssitUtilities.PlusAndKill(false, false, pairFactor[0]) + "x" 
                                    + AssitUtilities.PlusAndKill(false, false, pairFactor[1]) + "x" 
                                    + AssitUtilities.PlusAndKill(false, true, c) + " = 0"
                                    .ToString(),
                    Description = "xxxxxxxx"
                });
            }
            else
            {
                //TODO
                solution.Add(new QuadraticSolutionDto(){
                    SolutionLine = "x = ( - (" + b + ") + √(" + b + "² - 4*" + a + "*" + c + " )) / ( 2*" + a + " )  Or,  x = ( - (" + b + ") - √(" + b + "² - 4*" + a + "*" + c + " )) / ( 2*" + a + " )",
                    Description = "A"
                });
                double result1 = ((-1*b) + Math.Sqrt((b*b) - (4*a*c)))/(a*2);
                double result2 = ((-1*b) - Math.Sqrt((b*b) - (4*a*c)))/(a*2);
                solution.Add(new QuadraticSolutionDto(){
                    SolutionLine = "x = " + Math.Round(result1, 2) + " Or, x = " + Math.Round(result2, 2),
                    Description = "AAA"
                });
                return solution;
            }

            int gcd1 = MathUtilities.GCD(new int[] {pairFactor[0], a});
            int gcd2 = MathUtilities.GCD(new int[] {pairFactor[1], c});

            solution.Add(new QuadraticSolutionDto()
            {
                SolutionLine = (AssitUtilities.PlusAndKill(true, false, gcd1) + "x(" 
                                + AssitUtilities.PlusAndKill(true, false, a/gcd1) + "x" 
                                + AssitUtilities.PlusAndKill(false, true, pairFactor[0]/gcd1) + ")" 
                                + AssitUtilities.PlusAndKill(false, true, gcd2) + "(" 
                                + AssitUtilities.PlusAndKill(true, false, pairFactor[1]/gcd2) + "x" 
                                + AssitUtilities.PlusAndKill(false, true, c/gcd2) + ")") + " = 0"
                                .ToString(),
                Description = "xxxxxxxx"
            });

            solution.Add(new QuadraticSolutionDto()
            {
                SolutionLine = ("(" 
                                + AssitUtilities.PlusAndKill(true, false, a/gcd1) + "x" 
                                + AssitUtilities.PlusAndKill(false, true, pairFactor[0]/gcd1) + ")(" 
                                + AssitUtilities.PlusAndKill(true, false, gcd1) + "x" 
                                + AssitUtilities.PlusAndKill(false, true, gcd2) +")") + " = 0"
                                .ToString(),
                Description = "xxxxxxxx"
            });

            solution.Add(new QuadraticSolutionDto()
            {
                SolutionLine = ("Hence, (" 
                                + AssitUtilities.PlusAndKill(true, false, a/gcd1) + "x" 
                                + AssitUtilities.PlusAndKill(false, true, pairFactor[0]/gcd1) + ") = 0 or (" 
                                + AssitUtilities.PlusAndKill(true, false, gcd1) + "x" 
                                + AssitUtilities.PlusAndKill(false, true, gcd2) +") = 0")
                                .ToString(),
                Description = "xxxxxxxxxxxxx"
            });

            solution.Add(new QuadraticSolutionDto()
            {
                SolutionLine = ("therefore, " 
                                + AssitUtilities.PlusAndKill(true, false, a/gcd1) + "x = " 
                                + AssitUtilities.PlusAndKill(true, true, -1 * pairFactor[0]/gcd1) + " or, " 
                                + AssitUtilities.PlusAndKill(true, false, gcd1) + "x = " 
                                + AssitUtilities.PlusAndKill(true, true, -1 * gcd2))
                                .ToString(),
                Description = "xxxxxxxxxxxxx"
            });

            int nominatorA = -1 * pairFactor[0]/gcd1;
            int denominatorA = a/gcd1;

            int nominatorB = -1 * gcd2;
            int denominatorB = gcd1;

            string resultA = AssitUtilities.Fraction(nominatorA, denominatorA);
            string resultB = AssitUtilities.Fraction(nominatorB, denominatorB);

            solution.Add(new QuadraticSolutionDto()
            {
                SolutionLine = ("x = " 
                                + resultA + " or, " 
                                + "x = " 
                                + resultB)
                                .ToString(),
                Description = "xxxxxxxxxxxxx"
            });


            if(MathUtilities.GCD(nominatorA, denominatorA) == 1 || MathUtilities.GCD(nominatorB, denominatorB) == 1
               || MathUtilities.GCD(nominatorA, denominatorA) == -1 || MathUtilities.GCD(nominatorB, denominatorB) == -1)
                return solution;
            
            resultA = AssitUtilities.Katakati(nominatorA, denominatorA);
            resultB = AssitUtilities.Katakati(nominatorB, denominatorB);

            solution.Add(new QuadraticSolutionDto()
            {
                SolutionLine = ("x = " 
                                + resultA + " or, " 
                                + "x = " 
                                + resultB)
                                .ToString(),
                Description = "xxxxxxxxxxxxx"
            });

            return solution;
        }

        public List<TrinomialSolutionDto> Trinomial(string equation,int a = 1, int b = 1, int c = 0)
        {
            List<TrinomialSolutionDto> solution =  new List<TrinomialSolutionDto>();

            // var terms =  equation.Split(new char[] {'+', '-'}).Select(t => t.Trim());


            // char v = 'x';

            // int a;
            // int b;
            // int c;

            int d = a * c;
            var factors = d.Divisors();

            var pairFactor = AssitUtilities.MidTermFactorPair(factors, b, d);

            if(pairFactor[0] != 0 && pairFactor[1] != 0)
            { 
                solution.Add(new TrinomialSolutionDto()
                {
                    SolutionLine = AssitUtilities.PlusAndKill(true, false, a) + "x^2" 
                                    + AssitUtilities.PlusAndKill(false, false, pairFactor[0]) + "x" 
                                    + AssitUtilities.PlusAndKill(false, false, pairFactor[1]) + "x" 
                                    + AssitUtilities.PlusAndKill(false, true, c)
                                    .ToString(),
                    Description = "xxxxxxxx"
                });
            }
            else 
            {
                solution.Add(new TrinomialSolutionDto()
                {
                    SolutionLine = "There is no other factor but itselt!",
                    Description = "xxxxxxxxxxxxxx"
                });

                return solution;
            }

            int gcd1 = MathUtilities.GCD(new int[] {pairFactor[0], a});
            int gcd2 = MathUtilities.GCD(new int[] {pairFactor[1], c});

            solution.Add(new TrinomialSolutionDto()
            {
                SolutionLine = (AssitUtilities.PlusAndKill(true, false, gcd1) + "x(" 
                                + AssitUtilities.PlusAndKill(true, false, a/gcd1) + "x" 
                                + AssitUtilities.PlusAndKill(false, true, pairFactor[0]/gcd1) + ")" 
                                + AssitUtilities.PlusAndKill(false, true, gcd2) + "(" 
                                + AssitUtilities.PlusAndKill(true, false, pairFactor[1]/gcd2) + "x" 
                                + AssitUtilities.PlusAndKill(false, true, c/gcd2) + ")")
                                .ToString(),
                Description = "xxxxxxxx"
            });

            solution.Add(new TrinomialSolutionDto()
            {
                SolutionLine = ("(" 
                                + AssitUtilities.PlusAndKill(true, false, a/gcd1) + "x" 
                                + AssitUtilities.PlusAndKill(false, true, pairFactor[0]/gcd1) + ")(" 
                                + AssitUtilities.PlusAndKill(true, false, gcd1) + "x" 
                                + AssitUtilities.PlusAndKill(false, true, gcd2) +")")
                                .ToString(),
                Description = "xxxxxxxx"
            });

            return solution;      
        }

        public List<TrinomialSolutionDto> Square(int a = 1, int b = 1)
        {
             List<TrinomialSolutionDto> solution =  new List<TrinomialSolutionDto>();

             solution.Add(new TrinomialSolutionDto()
             {
                 SolutionLine = ("(" + AssitUtilities.PlusAndKill(true, false, a) + "x " + AssitUtilities.PlusAndKill(false, false, b) + "y)²").ToString(),
                Description = "Square Line first"
             });

             solution.Add(new TrinomialSolutionDto() {
                 SolutionLine = AssitUtilities.PlusAndKill(true, true, a)+"²x² " + " +2("+AssitUtilities.PlusAndKill(true, false, a)+"x)("+AssitUtilities.PlusAndKill(true, false, b)+"y) " + AssitUtilities.PlusAndKill(false, true, b)+"²y²".ToString(),
                 Description = "Formula Applied"
             });

             int c = 2*a*b;
             a *= a;
             b *= b;
             

             solution.Add(new TrinomialSolutionDto() {
                 SolutionLine = AssitUtilities.PlusAndKill(true, false, a)+"x²" + AssitUtilities.PlusAndKill(false, false, c)+"xy " + AssitUtilities.PlusAndKill(false, false, b)+"y²".ToString(),
                 Description = "Formula Applied"
             });

             int gcd = MathUtilities.GCD(new int[] {a, b, c});

            if(gcd != 1){
                solution.Add(new TrinomialSolutionDto() {
                 SolutionLine = gcd+"( "+AssitUtilities.PlusAndKill(true, false, a/gcd)+"x²" + AssitUtilities.PlusAndKill(false, false, c/gcd)+"xy " + AssitUtilities.PlusAndKill(false, false, b/gcd)+"y²)".ToString(),
                 Description = "Formula Applied"
             });
            }

             return solution;
        }
    }
}