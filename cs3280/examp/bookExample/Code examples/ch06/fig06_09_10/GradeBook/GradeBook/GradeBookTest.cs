﻿// Fig. 6.10: GradeBookTest.cs
// Create GradeBook object, input grades and display grade report.

public class GradeBookTest
{
   public static void Main( string[] args )
   {
      // create GradeBook object myGradeBook and 
      // pass course name to constructor
      GradeBook myGradeBook = new GradeBook(
         "CS101 Introduction to C# Programming" );

      myGradeBook.DisplayMessage(); // display welcome message
      myGradeBook.InputGrades(); // read grades from user
      myGradeBook.DisplayGradeReport(); // display report based on grades
   } // end Main
} // end class GradeBookTest

/**************************************************************************
 * (C) Copyright 1992-2009 by Deitel & Associates, Inc. and               *
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