﻿// Fig. 16.1: StringConstructor.cs
// Demonstrating string class constructors.
using System;

class StringConstructor
{
   public static void Main( string[] args )
   {
      // string initialization
      char[] characterArray = 
         { 'b', 'i', 'r', 't', 'h', ' ', 'd', 'a', 'y' };
      string originalString = "Welcome to C# programming!";
      string string1 = originalString;
      string string2 = new string( characterArray );
      string string3 = new string( characterArray, 6, 3 );
      string string4 = new string( 'C', 5 );

      Console.WriteLine( "string1 = " + "\"" + string1 + "\"\n" +
         "string2 = " + "\"" + string2 + "\"\n" +
         "string3 = " + "\"" + string3 + "\"\n" +
         "string4 = " + "\"" + string4 + "\"\n" );
   } // end Main
} // end class StringConstructor

/**************************************************************************
 * (C) Copyright 1992-2011 by Deitel & Associates, Inc. and               *
 * Pearson Education, Inc. All Rights Reserved.                           *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/