using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformaticaTeoricaTarea2
{
    /// <summary>
    /// Clase que se encarga de identificar una gramatica. 
    /// </summary>
    class Grammar
    {
        //*********************************
        //         ATRIBUTOS
        //*********************************

        /// <summary>
        /// Aquí estaran guardadas las producciones 
        /// </summary>
        public List<Production> rules;

        /// <summary>
        /// Se encarga de almacenar las variables usadas por el usuario en su gramatica.
        /// </summary>
        public List<string> variables;

        /// <summary>
        /// Se encarga de almacenar las variables terminales de la gramatica.
        /// </summary>
        public List<string> terminals;

        /// <summary>
        /// Se encarga de guardar todas las variables que se pueden usar en la gramatica.
        /// </summary>
        public List<string> availableVariables = new List<string>(){ "A","B", "C", "D", "E","F","G","H","I","J","K","L","M",
             "N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};

        public List<string> availableVariableTerminals = new List<string>() {"Ta", "Tb", "Tc", "Td", "Te", "Tf", "Tg", "Th", "Ti", "Tj",
            "Tk", "Tl", "Tm", "Tn", "To", "Tp", "Tq", "Tr", "Ts", "Tt", "Tu", "Tv", "Tw", "Tx", "Ty", "Tz"};

        public List<string> availableVariableBinary = new List<string>() {"T1", "T2", "T3", "T4", "T5", "T6", "T7", "T8", "T9", "T10",
            "T11", "T12", "T13", "T14", "T15", "T16", "T17", "T18", "T19", "T20", "T21", "T22", "T23", "T24", "T25", "T26"};

        /// <summary>
        /// Nuevas producciones que se generan al obtener las producciones binarias
        /// </summary>
        public List<Production> newProductions = new List<Production>();


        //************************************
        //********** CONSTRUCTOR *************
        //************************************

        /// <summary>
        /// Se encarga de generar la gramatica con un formato especifico digitado por el usuario.
        /// </summary>
        /// <param name="texto">
        ///  Es la gramatica ingresada por el usuario. 
        /// </param>
        /// <exception cref="System.Exception">
        /// Lanza excepciones si la gramatica no cumple con el formato especifico.
        /// </exception>
        public Grammar(string texto)
        {
            rules = new List<Production>();
            variables = new List<string>();
            terminals = new List<string>();

            string[] lineas = texto.Split('\n');
            for (int i = 0; i < lineas.Count(); i++)
            {
                string linea = lineas.ElementAt(i);


                if (linea != null && linea.Trim().Count() != 0)
                {
                    linea = linea.Replace(" ", "");

                    
                    String[] partes = linea.Split(':');
                    if (partes.Length != 2)
                    {
                        throw new Exception("Regla sin el formato : " + linea);
                    }

                    if (partes[0].Length != 1)
                    {
                        throw new Exception("La parte izquierda de una regla debe ser un caracter");
                    }

                    
                    char generador = partes[0].ElementAt(0);
                    if (generador < 'A' || generador > 'Z' || generador.Equals(Convert.ToChar(Production.LAMBDA)))
                    {
                        throw new Exception("El generador debe ser una letra mayuscula");
                    }

                    
                    string[] producciones = partes[1].Split('|');
                    for (int j = 0; j < producciones.Count(); j++)
                    {
                        string prod = producciones.ElementAt(j).Trim(); 

                        
                        for (int z = 0; z < prod.Count(); z++)
                        {
                            string c = Char.ToString(prod.ElementAt(z));

                            if (c.Equals(Production.LAMBDA) == false)
                            {
                                if (Char.IsLetter(Convert.ToChar(c)) == false)
                                {
                                    throw new Exception("el caracter " + c + " no es un terminal, variable o lambda");
                                }
                                
                                else if (Char.IsLower(Convert.ToChar(c)))
                                {
                                    if (terminals.Contains(c) == false)
                                    {
                                        terminals.Add(c);
                                    }
                                }
                                else if (Char.IsUpper(Convert.ToChar(c)))
                                {
                                    if (variables.Contains(c) == false)
                                    {
                                        variables.Add(c);
                                        availableVariables.Remove(c);
                                    }
                                }
                                
                            }
                            else
                            {
                                if (prod.Count() > 1)
                                {
                                    throw new Exception("Lambda debe aparecer sola y una unica vez en una produccion");
                                }
                            }
                        }

                        producciones[j] = prod;
                    }

                   
                    Production nueva = new Production(Char.ToString(generador), producciones.ToList<string>()); //todo correcto
                    rules.Add(nueva);

                    if (variables.Contains(Char.ToString(generador)) == false)
                    {
                        variables.Add(Char.ToString(generador));
                    }


                }
            }
        }

        
        /// <summary>
        /// Obtiene las variables terminables de la gramatica
        /// </summary>
        /// <returns>
        /// Retorna una lista con las variables terminables
        /// </returns>
        public List<string> getTerminables()
        {
            List<string> terminables = new List<string>();

            
            foreach (Production prod in rules)
            {

                if (prod.isProductionTerminable() == true)
                {
                    terminables.Add(prod.generator);
                }
            }

            
            bool cambio = true;
            while (cambio)
            {
                List<string> terminablesIniciales = new List<string>(terminables);

                foreach (Production regla in rules)
                {
                    string generador = regla.generator;
                    if (terminables.Contains(generador) == false)
                    {

                        if (regla.isProductionTerminableByVariableTerminable(terminables) == true)
                        {
                            terminables.Add(generador);
                        }
                    }
                }

                if (terminablesIniciales.Count() == terminables.Count())
                {
                    cambio = false;
                }
            }

            terminables.Distinct();

            return terminables;
        }

        
        /// <summary>
        /// Obtiene las variables no terminables de la gramatica
        /// </summary>
        /// <returns>
        /// Retorna una lista con las variables no terminables
        /// </returns>
        public List<string> getNoTerminables()
        {
            List<string> generadores = getGenerators();

            return generadores.Except(getTerminables()).ToList<string>();
        }

        
        /// <summary>
        /// Obtiene las variables alcanzables de la gramatica
        /// </summary>
        /// <returns>
        /// Retorna una lista con las variables alcanzables
        /// </returns>
        public List<string> getAttainable()
        {
            
            List<string> alcanzables = new List<string>() { "S" };
            List<string> yaAnalizadas = new List<string>();

           
            bool cambio = true;
            while (cambio)
            {
                List<string> alcanzablesIniciales = new List<string>(alcanzables);
                foreach (string c in alcanzables)
                {
                    if (yaAnalizadas.Contains(c) == false)
                    {
                        Production regla = giveProductions(c);
                        if (regla != null)
                        {
                            List<string> variablesAlcanzables = regla.attainableVariables();
                            alcanzables = alcanzables.Union(variablesAlcanzables).ToList<string>();
                        }
                        yaAnalizadas.Add(c);
                    }
                }
                if (alcanzablesIniciales.Count() == alcanzables.Count())
                {
                    cambio = false;
                }
            }

            return alcanzables;
        }

      
        /// <summary>
        /// Obtiene las variables no alcanzables de la gramatica
        /// </summary>
        /// <returns>
        /// Retorna una lista con las variables no alcanzables
        /// </returns>
        public List<string> getNoAttainable()
        {
            List<string> generadores = getGenerators();

            return generadores.Except(getAttainable()).ToList<string>();
        }

       
        /// <summary>
        /// Obtiene las variables anulables de la gramatica
        /// </summary>
        /// <returns>
        /// Retorna una lista con las variables anulables
        /// </returns>
        public List<string> getVoidable()
        {
            List<string> anulables = new List<string>();

            
            foreach (Production regla in rules)
            {
                if (regla.isVoidableByProduction() == true)
                {
                    anulables.Add(regla.generator);
                }
            }

            
            bool cambio = true;
            while (cambio)
            {
                List<string> anulablesIniciales = new List<string>(anulables);

                foreach (Production regla in rules)
                {
                    if (anulables.Contains(regla.generator) == false)
                    {
                        if (regla.isProductionsVoidableByVoidableVariable(anulables) == true)
                        {
                            anulables.Add(regla.generator);
                        }
                    }
                }

                if (anulablesIniciales.Count() == anulables.Count())
                {
                    cambio = false;
                }
            }
            return anulables;
        }

       
        /// <summary>
        /// Obtiene el conjunto unitario de una variable
        /// </summary>
        /// <param name="generador">
        /// Representa la variable a la cual se calcula el conjunto unitario
        /// </param>
        /// <returns>
        /// Una lista con las variables pertenecientes al conjunto unitario de la variable pasada como parametro
        /// </returns>
        public List<string> getUnitarySet(string generador)
        {
           
            List<string> conjunto = new List<string>() { generador };
            List<string> yaEstudiado = new List<string>();

           
            bool cambio = true;
            while (cambio)
            {
                List<string> conjuntoInicial = new List<string>(conjunto);

                foreach (string caracter in conjunto)
                {
                    if (yaEstudiado.Contains(caracter) == false)
                    {
                        Production regla = giveProductions(caracter);
                        if (regla != null)
                        {
                            conjunto = conjunto.Union(regla.unitProductions()).ToList<string>();
                        }
                        yaEstudiado.Add(caracter);
                    }
                }

                if (conjuntoInicial.Count() == conjunto.Count())
                {
                    cambio = false;
                }
            }

            return conjunto;
        }

        
        /// <summary>
        /// Obtiene todas las variables que actuan como generadores. Una variable actua como generador si tiene
        /// una regla asociada.
        /// </summary>
        /// <returns>
        /// Una lista con todas las variables de la gramatica que tienen un cuerpo asociado
        /// </returns>
        public List<string> getGenerators()
        {
            List<string> respuesta = new List<string>();

            foreach (Production regla in rules)
            {
                respuesta.Add(regla.generator);
            }

            return respuesta;
        }

       
        /// <summary>
        /// Obtiene la produccion asociada a una variable
        /// </summary>
        /// <param name="generador">
        /// Representa la variable de la cual se quiere obtener su produccion
        /// </param>
        /// <returns>
        /// Un objeto Production que representa la produccion asociada a la variable pasada como parametro
        /// </returns>
        public Production giveProductions(string generador)
        {
            var busqueda = rules.Where(r => r.generator.Equals(generador));

            if (busqueda.Count() == 0)
            {
                return null;
            }
            else
            {
                var regla = (Production)busqueda.ElementAt(0);
                return regla;
            }
        }

       
        /// <summary>
        /// Metodo que elimina todas las variables no terminables de la gramatica.
        /// Al eliminar una variable no terminable se pierde su cuerpo asociada y todas las producciones que la contenian
        /// </summary>
        public void removeNoTerminables()
        {
            List<string> terminables = getTerminables();
            List<string> generadores = getGenerators();

            List<string> noTerminables = generadores.Except(terminables).ToList<string>();

            foreach (string noTerminable in noTerminables)
            {
              
                Production regla = giveProductions(noTerminable);
                if (regla != null)
                {
                    rules.Remove(regla);
                }
            }

           
            foreach (Production rule in rules)
            {
                rule.removeProductionsWithUselessVariables(noTerminables);
                if (rule.productions.Count() == 0)
                {
                    rules.Remove(rule);
                }
            }
        }

        
        /// <summary>
        /// Metodo que elimina todas las variables no alcanzables de la gramatica.
        /// Al eliminar una variable no alcanzable se pierde su cuerpo asociada y todas las producciones que la contenian
        /// </summary>
        public void removeNoAttainable()
        {
            List<string> alcanzables = getAttainable();
            List<string> generadores = getGenerators();

            List<string> noAlcanzables = generadores.Except(alcanzables).ToList<string>();

            foreach (string noAlc in noAlcanzables)
            {
                
                Production regla = giveProductions(noAlc);
                if (regla != null)
                {
                    rules.Remove(regla);
                }
            }

            
            foreach (Production rule in rules)
            {
                rule.removeProductionsWithUselessVariables(noAlcanzables);
                if (rule.productions.Count() == 0)
                {
                    rules.Remove(rule);
                }
            }



        }

       
        /// <summary>
        /// Metodo que elimina y simula, añadiendo nuevas producciones, todas las producciones labmda.
        /// </summary>
        public void removeLambdaProductions()
        {
            List<string> anulables = getVoidable();

            foreach (Production regla in rules)
            {
                regla.simulateProductionsLambda(anulables);

            }
        }

        
        /// <summary>
        /// Metodo que elimina y simula, añadiendo nuevas producciones, todas las producciones unitarias
        /// </summary>
        public void removeUnitariesProductions()
        {
            List<string> generadores = getGenerators();

            foreach (string gen in generadores)
            {
                List<string> conjuntoUnitario = getUnitarySet(gen);
                Production rule = giveProductions(gen);
                rule.removeUnitProductions();

                foreach (string variable in conjuntoUnitario)
                {
                    if (variable.Equals(gen) == false)
                    {
                        Production regla = giveProductions(variable);
                        if (regla != null)
                        {
                            List<string> produccionesNuevas = regla.getNoUnitProductions();
                            rule.setProductions(produccionesNuevas);
                        }
                    }
                }
            }

        }

       
        /// <summary>
        /// Toda produccion con tamaño mayor a 1 y que contenga un terminal, debe reemplazar dicho terminal por
        /// una variable. Este metodo realiza esta tarea teniendo como recurso las variables posibles y las variables
        /// hasta el momento utilizadas.
        /// Se añaden nuevas producciones con el terminal reemplazado
        /// </summary>
        public void generateVariablesForEachTerminal()
        {
            List<string> variablesPermitidas = availableVariables.Except(variables).ToList<string>(); //para asegurar
            int numeroDeReglas = rules.Count();

            
            Dictionary<string, string> asignaciones = new Dictionary<string, string>();
            for (int i = 0; i < terminals.Count(); i++)
            {

                string terminal = terminals.ElementAt(i);
                string variableAsignada = availableVariableTerminals.Find(x => x == "T" + terminal);



                
                asignaciones.Add(terminal, variableAsignada);

         
                variables.Add(variableAsignada);
                availableVariableTerminals.Remove(variableAsignada);

            }

            
            for (int y = 0; y < numeroDeReglas; y++)
            {
                Production reg = rules.ElementAt(y);
                List<string> producciones = new List<string>(reg.productions);
               // Console.WriteLine("Soy el Generador: "+reg.generator);

                for (int x = 0; x < producciones.Count(); x++)
                {
                    //Console.WriteLine("Mis producciones son: "+producciones.Count());
                    string produccion = producciones.ElementAt(x);
                    bool isContinuo = true;

                    //Console.WriteLine("Soy la produccion: "+produccion);

                    if (produccion.Count() > 1)
                    {
                        for (int i = 0; i < produccion.Count() && isContinuo; i++)
                        {
                            
                            string caracter = Char.ToString(produccion.ElementAt(i));
                            //Console.WriteLine("Soy el caracter: "+ caracter);

                            if (terminals.Contains(caracter))
                            {

                                //Console.WriteLine("Soy la terminal: " + caracter);

                                
                                if (i > 0 && produccion.ElementAt(i - 1) == 'T' && terminals.Contains(Char.ToString(produccion.ElementAt(i))))
                                {


                                    isContinuo = false;
                                   // Console.WriteLine("Entre al if: " + produccion.ElementAt(i));

                                }
                                else
                                {
                                    string variableAsignada = asignaciones[caracter];

                                    produccion = produccion.Replace(caracter, variableAsignada);
                                   // Console.WriteLine(produccion.Count() + " " + i);
                                   // Console.WriteLine("Ahora estoy como: " + produccion);
                                    i++;
                                    if (getGenerators().Contains(variableAsignada) == false)
                                    {

                                        //creo la regla nueva
                                        Production regla = new Production(variableAsignada, new List<string>() { caracter.ToString() });
                                        rules.Add(regla);
                                        newProductions.Add(regla);


                                    }

                                }

                            
                               

                            }

                            

                        }

                        producciones.Distinct();
                        producciones.Insert(x, produccion);
                        producciones.RemoveAt(x + 1);
                    }

                    

                }
                
                reg.productions = producciones;
            }
        }

        
        /// <summary>
        /// Convierte cada cuerpo de una produccion en un cuerpo binario
        /// </summary>
        public void generateBinaryProductions()
        {
            availableVariables = availableVariables.Except(variables).ToList<string>(); //para asegurar

            bool reglasBinarias = areAllProductionsBinary();
           // Console.WriteLine("Por fin acabe");
            while (reglasBinarias == false)
            {
                foreach (Production regla in rules)
                {
                    regla.getBinariesProductions(this);
                }
                //Console.WriteLine(this.ToString());
               // Console.WriteLine("Empece de nuevo");
                reglasBinarias = areAllProductionsBinary();
                rules = rules.Union(newProductions).ToList<Production>();

            }

        }

        
        /// <summary>
        /// Determina si todas las reglas de la gramatica tienen sus producciones en forma binaria.
        /// </summary>
        /// <returns>
        /// Retorna true si todas las reglas tienen sus producciones en forma binaria. En caso contrario, retorna false
        /// </returns>
        public bool areAllProductionsBinary()
        {
            bool respuesta = true;

            for (int i = 0; i < rules.Count() && respuesta; i++)
            {
                Production r = rules.ElementAt(i);
               // Console.WriteLine("El indice es: "+i);
               // Console.WriteLine("EMPECE A REVISAR A "+ r.generator);
                respuesta = r.isBinary();
 
            }

            

            return respuesta;
        }

        
        /// <summary>
        /// Busca sobre las nuevas producciones generadas
        /// una produccion que tenga al parametro como produccion.
        /// Las nuevas producciones generadas estan representadas por el atributo newProductions.
        /// </summary>
        /// <param name="prod">
        /// String que representa una produccion o un cuerpo de la produccion
        /// </param>
        /// <returns>
        /// Retorna la PRODUCCION que tiene como Cuerpo el parametro. En caso de que no encuentre ninguna regla,
        /// retorna null.
        /// </returns>
        public Production getProductionWith(string prod)
        {
            Production buscada = null;

            for (int i = 0; i < newProductions.Count() && buscada == null; i++)
            {
                Production r = newProductions.ElementAt(i);
                List<string> producciones = r.productions; //una lista de una unica produccion

                if (producciones.ElementAt(0).Equals(prod))
                {
                    buscada = r;
                }
            }

           // Console.WriteLine("estoy en regla unitaria:: "+buscada);

            return buscada;
        }


       
        /// <summary>
        /// Obtiene las variables que en su produccion asociada producen alguna de las producciones pasadas como parametro
        /// </summary>
        /// <param name="producciones">
        /// Lista de string que representa las producciones
        /// </param>
        /// <returns>
        /// Una lista de string con las variables
        /// </returns>
        public List<string> getGeneratorOfLessThanOneOfTheProductions(List<string> producciones)
        {
            List<string> respuesta = new List<string>();

            foreach (string prod in producciones)
            {
                foreach (Production reg in rules)
                {
                    if (reg.existProduction(prod))
                    {
                        string generador = reg.generator.ToString();
                        if (respuesta.Contains(generador) == false)
                        {
                            respuesta.Add(generador);
                        }
                    }
                }
            }

            return respuesta;
        }

        /// <summary>
        /// Genera producciones a partir de dos listas cuyo contenido son variables.
        /// </summary>
        /// <param name="lista1">
        /// Lista de string
        /// </param>
        /// <param name="lista2">
        /// Lista de string
        /// </param>
        /// <returns>
        /// Retorna una lista de string con las nuevas producciones
        /// </returns>
        public List<string> generatePossibleProductions(List<string> lista1, List<string> lista2)
        {
            List<string> respuesta = new List<string>();

            if (lista1.Count() == 0 && lista2.Count() > 0)
            {
                respuesta = lista2;
            }
            else if (lista1.Count() > 0 && lista2.Count() == 0)
            {
                respuesta = lista1;
            }
            else if (lista1.Count() > 0 && lista2.Count() > 0)
            {
                for (int i = 0; i < lista1.Count(); i++)
                {
                    string cad1 = lista1.ElementAt(i);

                    for (int j = 0; j < lista2.Count(); j++)
                    {
                        string cad2 = lista2.ElementAt(j);
                        string nuevo = cad1 + cad2;
                        respuesta.Add(nuevo);
                    }
                }
            }

            return respuesta;
        }


        /// <summary>
        /// Genera una cadena de texto que representa este objeto Gramatica
        /// </summary>
        /// <returns>
        /// Un string que representa este objeto Gramatica
        /// </returns>
        public override string ToString()
        {
            string cadena = "";

            foreach (Production regla in rules)
            {
                cadena = cadena + regla.ToString() + Environment.NewLine;
            }

            return cadena;
        }







    }
}
