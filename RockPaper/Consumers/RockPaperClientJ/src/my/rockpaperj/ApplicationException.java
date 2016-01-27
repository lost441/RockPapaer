/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package my.rockpaperj;

/**
 *
 * @author kmarais
 */
public class ApplicationException extends Exception
{
   private String message;
   public ApplicationException(String message)
   {
      this.message = message;
   } 
   public String getMessage()
   {
      return this.message;
   }
}
