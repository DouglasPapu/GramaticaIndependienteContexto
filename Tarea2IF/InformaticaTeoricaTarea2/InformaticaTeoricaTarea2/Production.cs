using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformaticaTeoricaTarea2
{

    
    /// <summary>
    /// Clase que se encarga de identificar una producción de la gramatica
    /// y válida el proceso de Chomsky en cada una.
    /// </summary>
    class Production
    {

        // Constantes

        /// <summary>
        /// Constante que permite identificar el lambda de la gramatica.
        /// </summary>
        public const string LAMBDA = "%";

        //Atributos

        /// <summary>
        /// Almacena el generador, es decir la variable.
        /// </summary>
        public string generator;


        /// <summary>
        /// Lista que guarda todas las producciones de un generador.
        /// </summary>
        public List<string> productions;


        /// <summary>
        /// Método constructor de la clase.
        /// </summary>
        /// <param name="generator"></param>
        /// <param name="productions"></param>
        public Production(string generator, List<string> productions)
        {
            this.generator = generator;
            this.productions = productions;

        }

        // ******************************* MÉTODOS DE LA CLASE ******************************************
       

        /// <summary>
        /// Se encarga de verificar si una producción es terminable por una variable terminable.
        /// </summary>
        /// <param name="terminables"></param>
        /// <returns name="reply"></returns>
        public bool isProductionTerminableByVariableTerminable(List<string> terminables)
        {
            bool reply = false;

            for (int i = 0; i < productions.Count && !reply; i++)
            {
                string produccion = productions.ElementAt(i);

                var cadena = produccion.Where(c => Char.IsLower(c) || terminables.Contains(Convert.ToString(c)));

                if (cadena.Count() == produccion.Count())
                {
                    reply = true;
                }
            }

            return reply;
        }


        

        /// <summary>
        /// Verifica si una produccion es terminable por contener unicamente variables terminables.
        /// </summary>
        /// <returns name="reply"></returns>
        public bool isProductionTerminable()
        {
            bool reply = false;

            for (int i = 0; i < productions.Count && !reply; i++)
            {
                string produccion = productions.ElementAt(i);
                

                if (produccion.ElementAt(0).Equals(Convert.ToChar(LAMBDA)))
                {
                    
                    reply = true;
                }
                else
                {
                    var cadena = produccion.Where(c => Char.IsLower(c));
                    

                    if (cadena.Count() == produccion.Count())
                    {
                        reply = true;
                    }
                }
               
            }

            return reply;
        }

        

        /// <summary>
        /// Obtiene las variables alcanzables, es decir las variables a las que puedo llegar 
        /// empezando por la produccion S.
        /// </summary>
        /// <returns name="attainable">
        /// Devuelve una lista con las variables alcanzables.
        /// </returns>
        public List<string> attainableVariables()
        {
            List<string> attainable = new List<string>();
            int i = 0;
            List<char> lista = new List<char>();
            List<string> lista2 = new List<string>();

            foreach (string produccion in productions)
            {
                lista = produccion.Where(c => Char.IsUpper(c)).ToList<char>();

                foreach (char pr in lista)
                {
                    lista2.Add(Convert.ToString(pr));
                    attainable = attainable.Union(lista2).ToList<string>();
                }

            }
            return attainable;
        }

        

        /// <summary>
        /// Verifica si una producción es anulable por variables anulables.
        /// </summary>
        /// <param name="voidable"></param>
        /// <returns name="answer">
        /// Devuelve true si la producción es anulable por variables anulables, false en caso contrario.
        /// </returns>
        public bool isProductionsVoidableByVoidableVariable(List<string> voidable)
        {
            bool answer = false;

            for (int i = 0; i < productions.Count && !answer; i++)
            {
                string production = productions.ElementAt(i);

                var cinta = production.Where(c => voidable.Contains(Char.ToString(c)));
                if (cinta.Count() == production.Count())
                {
                    answer = true;
                }

            }

            return answer;
        }

        

        /// <summary>
        /// Verifica si la produccion es anulable por el hecho de tener %. (Lambda).
        /// </summary>
        /// <returns name="answer">
        /// Devuelve true si la producción es anulable, false en caso contrario.
        /// </returns>
        public bool isVoidableByProduction()
        {
            bool answer = false;

            for (int i = 0; i < productions.Count() && !answer; i++)
            {
                string production = productions.ElementAt(i);
                if (production.Equals(LAMBDA.ToString()))
                {
                    answer = true;
                }
            }

            return answer;
        }

        

        /// <summary>
        /// Se encarga de devolver las producciones que son unitarias.
        /// </summary>
        /// <returns name="reply">
        /// Devuelve una lista con todas las producciones unitarias.
        /// </returns>
        public List<string> unitProductions()
        {
            List<string> reply = new List<string>();

            for (int i = 0; i < productions.Count(); i++)
            {
                string production = productions.ElementAt(i);
                if (production.Count() == 1)
                {
                    string character = Convert.ToString(production.ElementAt(0));
                    if (Char.IsUpper(Convert.ToChar(character)) == true)
                    {
                        reply.Add(character);
                    }
                }
            }
            return reply;
        }

       

        /// <summary>
        /// Se encarga de borrar las variables inutiles de las producciones de la GIC.
        /// </summary>
        /// <param name="variables"></param>
        public void removeProductionsWithUselessVariables(List<string> variables)
        {
            List<string> remove = new List<string>();

            foreach (string variable in variables)
            {
                foreach (string production in productions)
                {
                    if (production.Contains(variable) == true)
                    {
                        if (remove.Contains(production) == false)
                        {
                            remove.Add(production);
                        }
                    }
                }
            }

            productions = productions.Except(remove).ToList<string>();

        }

        

        /// <summary>
        /// Simula las producciones lambdas en la GIC.
        /// </summary>
        /// <param name="voidables"></param>
        public void simulateProductionsLambda(List<string> voidables)
        {
            List<string> recent = new List<string>();


            foreach (string production in productions)
            {

                List<string> roster = new List<string>();
                List<int> position = new List<int>();
                for (int x = 0; x < production.Count(); x++)
                {
                    string character = Convert.ToString(production.ElementAt(x));
                    if (voidables.Contains(character) == true)
                    {
                        roster.Add(character);
                        position.Add(x);
                    }
                }


                if (roster.Count() > 0)
                {

                    int voidableNumber = roster.Count();
                    int limit = (int)Math.Pow(2, voidableNumber);
                    List<string> options = generateBinaries(voidableNumber, limit);


                    for (int i = 0; i < options.Count(); i++)
                    {
                        string newProduction = production;
                        string option = options.ElementAt(i);

                        List<int> positionRemove = new List<int>();
                        for (int j = 0; j < option.Count(); j++)
                        {
                            string voidable = roster.ElementAt(j);
                            char decision = option.ElementAt(j);

                            if (decision.Equals('1') == true)
                            {
                                int positions = position.ElementAt(j);
                                positionRemove.Add(positions);
                            }
                        }

                        if (positionRemove.Count() > 0)
                        {

                            int contador = 0;
                            for (int w = 0; w < positionRemove.Count(); w++)
                            {
                                int pos = positionRemove.ElementAt(w) - contador;
                                newProduction = newProduction.RemoveAt(pos);

                                contador++;
                            }
                        }

                        if (newProduction.Equals(production) == false)
                        {
                            if (newProduction.Count() == 0 && generator.Equals("S"))
                            {
                                newProduction = LAMBDA.ToString();
                                recent.Add(newProduction);
                            }
                            else if (newProduction.Count() > 0)
                            {
                                recent.Add(newProduction);
                            }
                        }
                    }
                }
            }

            productions.Remove(LAMBDA.ToString());
            productions = productions.Union(recent).ToList<string>();
        }


        

        /// <summary>
        /// Genera la lista de numeros binarios en una cadena.
        /// </summary>
        /// <param name="components">
        /// Simplemente indica la cantidad de binarios que se tienen en cuenta al generar.
        /// </param>
        /// <param name="limit">
        /// dice cuantos binarios crear.
        /// </param>
        /// <returns name="roster">
        /// devuelve una lista de los binarios en una cadena.
        /// </returns>
        public List<string> generateBinaries(int components, int limit)
        {
            List<string> roster = new List<string>();

            for (int i = 0; i < limit; i++)
            {
                string binary = decimalToBinary(i, components);
                roster.Add(binary);
            }

            return roster;

        }

        

        /// <summary>
        /// Se encarga de convertir un numero decimal a binario.
        /// </summary>
        /// <param name="number">
        /// Numero decimal a convertir.
        /// </param>
        /// <param name="components">
        /// Es la cantidad de binarios que debe tener el numero.
        /// </param>
        /// <returns>
        /// un string del numero binario.
        /// </returns>
        public string decimalToBinary(int number, int components)
        {
            string departure = "";

            int decTen = number;
            int binary;

            while (decTen > 0)
            {
                binary = decTen % 2;
                decTen = decTen / 2;

                departure = binary + departure;
            }

            int size = departure.Count();
            while (size != components)
            {
                departure = "0" + departure;
                size = departure.Count();
            }

            return departure;
        }

        


        /// <summary>
        /// Se encarga de encontrar las producciones no unitarias.
        /// </summary>
        /// <returns name="answer">
        /// Devuelve una lista con las producciones no unitarias.
        /// </returns>
        public List<string> getNoUnitProductions()
        {
            List<string> answer = new List<string>();

            for (int i = 0; i < productions.Count(); i++)
            {
                string production = productions.ElementAt(i);

               
                if (production.Count() != 1)
                {
                    answer.Add(production);
                }
                else if (Char.IsLower(production.ElementAt(0)) == true)
                {
                    answer.Add(production);
                }
                else if (production.ElementAt(0).Equals(Convert.ToChar(LAMBDA)))
                {
                    answer.Add(production);
                }

            }



            return answer;
        }

        //modificarProducciones

        /// <summary>
        /// Se encarga de añadir nuevas producciones a la lista de producciones de la gramatica.
        /// </summary>
        /// <param name="newProductions"></param>
        public void setProductions(List<string> newProductions)
        {
            productions = productions.Union(newProductions).ToList<string>();
        }

        //eliminarProduccionesUnitarias

        /// <summary>
        /// Se encarga de eliminar las producciones no unitarias de la gramatica.
        /// </summary>
        public void removeUnitProductions()
        {
            productions = getNoUnitProductions();
        }

       

        /// <summary>
        /// Se encarga de transformar las producciones en producciones binarias
        /// </summary>
        /// <param name="g">
        /// Un objeto de tipo Grammar que tiene las reglas de esta clase.
        /// </param>
        public void getBinariesProductions(Grammar g)
        {
            List<string> recent = new List<string>();
            for (int i = 0; i < productions.Count(); i++)
            {
                
                string production = productions.ElementAt(i);
                
                List<String> prod = validateProductionsT(production);
                
                int tamanio = prod.Count();
                
                if (tamanio > 2) //produccion no binaria
                {
                   // Console.WriteLine("Soy la produccion "+production);
                    string caracter1 = prod.ElementAt(tamanio - 1);
                    string caracter2 = prod.ElementAt(tamanio - 2);

                    string nuevaProduccion = caracter2 + caracter1;

                   // Console.WriteLine("Soy la nueva produccion: "+nuevaProduccion);

                    Production rules = g.getProductionWith(nuevaProduccion);

                    //Console.WriteLine(rules);

                    if (rules != null)
                    {
                        

                        prod.RemoveAt(prod.Count() - 1);
                        prod.RemoveAt(prod.Count() - 1);
                        prod.Add(rules.generator.ToString());
                        string aux = convertListToString(prod);
                        recent.Add(aux);        
                    }
                    else
                    {
                        

                       // Console.WriteLine("Entre al else");

                        string variable = g.availableVariableBinary.ElementAt(0);
                        g.availableVariableBinary.RemoveAt(0); 
                        g.variables.Add(variable);

                        //Console.WriteLine("Soy la variable: "+variable);
                        
                        Production actually = new Production(variable, new List<string> { nuevaProduccion });
                        g.newProductions.Add(actually);

                        
                        
                        prod.RemoveAt(prod.Count() - 1);
                        prod.RemoveAt(prod.Count() - 1);
                        prod.Add(variable);
                        string aux2 = convertListToString(prod);
                        //Console.WriteLine("Soy aux2::"+aux2);

                        recent.Add(aux2);

                        
                    }
                }
                else
                {
                    recent.Add(production);
                }

            }

            productions = recent;

        }

        /// <summary>
        /// Se encarga de convertir una lista de cuerpos de la produccion
        /// en un string.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns name="aux">
        /// La lista concatenada en un string.
        /// </returns>
        public String convertListToString(List<string> ab)
        {
            string aux = "";

            foreach (string x in ab)
            {

                aux += x;
            }

            return aux;

        }

        

        /// <summary>
        /// Se encarga de decir si la produccion es binaria, es decir constan de dos variables o una terminal.
        /// </summary>
        /// <returns>
        /// Devuelve true si la produccion es Binaria. En otro caso, retorna false. 
        /// </returns>
        public bool isBinary()
        {
            bool reply = true;
           // Console.WriteLine(productions.Count());
            for (int i = 0; i < productions.Count() && reply; i++)
            {
                string production = productions.ElementAt(i);
                List<String> pr = validateProductionsT(production);
                //Console.WriteLine("SOY EL CUERPO " + production);
                //Console.WriteLine(pr.Count());
                if (pr.Count() == 1)
                {
                    //Console.WriteLine("Soy el elemento: "+pr.ElementAt(0));
                    char character = Convert.ToChar(pr.ElementAt(0));
                    if (Char.IsLower(character) == false && character.Equals(Convert.ToChar(LAMBDA)) == false) //si es una letra minuscula o lambda
                    {
                        reply = false;
                    }
                }
                else if (pr.Count() == 2)
                {
                    
                    //Console.WriteLine(pr.ElementAt(0));
                    //Console.WriteLine(pr.ElementAt(1));

                    if (pr.ElementAt(0).StartsWith("T"))
                    {
                        
                        if (pr.ElementAt(0).StartsWith("T") == false)
                        {
                            char character1 = Convert.ToChar(pr.ElementAt(0));
                            reply = false;
                        }

                        if (pr.ElementAt(1).Count() != 2) { 
                        char character2 = Convert.ToChar(pr.ElementAt(1));
                        if (Char.IsUpper(character2) == false)
                        {
                            reply = false;
                        }

                        }
                        else
                        {

                            if (pr.ElementAt(1).StartsWith("T") == false)
                            {
                                char character1 = Convert.ToChar(pr.ElementAt(0));
                                reply = false;
                            }

                        }
                    }
                    else if(pr.ElementAt(1).StartsWith("T"))
                    {  

                        //Cuando existe una Tn al final.
                        if (pr.ElementAt(1).StartsWith("T") == false)
                        {
                            reply = false;

                        }

                        if (Char.IsUpper(Convert.ToChar(pr.ElementAt(0))) == false)
                        {

                            reply = false;
                        }

                    }
                    else
                    {
                        char caracter1 = Convert.ToChar(pr.ElementAt(0));
                        char caracter2 = Convert.ToChar(pr.ElementAt(1));
                        if (Char.IsUpper(caracter1) == false || Char.IsUpper(caracter2) == false) //si ambas son mayusculas (variables)
                        {
                            reply = false;
                        }

                    }
                }
                else
                {
                    reply = false;
                }


                //Console.WriteLine("Soy la respuesta del cuerpo: " + reply);

            }

           

            return reply;
        }


        /// <summary>
        /// Se encarga de obtener una produccion y convertirla en un arreglo
        /// teniendo en cuenta las variables Tn como una sola. 
        /// </summary>
        /// <param name="prod"></param>
        /// <returns></returns>
        public List<String> validateProductionsT(String prod)
        {
            
            List<String> aux = new List<String>();
           

            for (int i = 0; i < prod.Length; i++)
            {
                if (i != prod.Length - 1)
                {
                    if (Convert.ToString(prod.ElementAt(i)).Equals("T") && Char.IsLower(prod.ElementAt(i + 1)) || Convert.ToString(prod.ElementAt(i)).Equals("T") && Char.IsNumber(prod.ElementAt(i + 1)))
                    {
                        String abc = Convert.ToString(prod.ElementAt(i)) + Convert.ToString(prod.ElementAt(i + 1));
                         aux.Add(abc);
                        i++;

                    }
                    else
                    {
                        aux.Add(Convert.ToString(prod.ElementAt(i)));
                    }
                }
                else
                {
                    aux.Add(Convert.ToString(prod.ElementAt(i)));
                }

            }

        

            

            return aux;

        }



        /// <summary>
        /// Verifica si existe una produccion en la gramatica
        /// </summary>
        /// <param name="production"></param>
        /// <returns>
        /// Retorna true si existe la produccion en la gramatica. En caso contrario, retorna false.
        /// </returns>
        public bool existProduction(string production)
        {
            return productions.Contains(production);
        }

        /// <summary>
        /// Genera una cadena de texto que representa este objeto Rules
        /// </summary>
        /// <returns>
        /// string que representa este objeto Rules.
        /// </returns>
        public override string ToString()
        {
            string cad = generator + " -> ";

            int size = productions.Count();

            for (int i = 0; i < size; i++)
            {
                string prod = productions.ElementAt(i);

                if (i == size - 1)
                {
                    cad = cad + prod;
                }
                else
                {
                    cad = cad + prod + " | ";
                }
            }

            return cad;
        }

    }
}
