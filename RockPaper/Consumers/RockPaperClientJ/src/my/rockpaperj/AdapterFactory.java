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
public class AdapterFactory {
    
    public static IGameAdapter GetGameAdapter(boolean useRest)
    {
        if(useRest)
        {
            return new RestGameAdapter();
        }
        else
        {
            return new WcfGameAdapter();
        }
    }
}
