/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package my.rockpaperj;

import java.util.Random;

/**
 *
 * @author kmarais
 */
public class HandGenerator {
  
public static JHand GenerateHand()
{
    //TODO LOGIC TO CHOOSE WHAT HAND TO PLAY
    //WILL DEFAULT TO A RANDOM HAND

    Random randomGenerator = new Random();
    int randomInt = randomGenerator.nextInt(4);
    switch(randomInt)
    {
        case 0:
            return JHand.Lizard;
        case 1:
            return JHand.Paper;
        case 2:
            return JHand.Rock;
        case 3:
            return JHand.Scissor;
        default:
            return JHand.Spock;
    }
  }
}
