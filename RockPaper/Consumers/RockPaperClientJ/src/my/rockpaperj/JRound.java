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
public class JRound {
    private String team1Hand;
    private String team2Hand;
    private JRoundResult result;
    private int roundNumber;
    
    public void Map(Round round)
    {
       this.team1Hand = round.team1Hand.getValue().toString();
       this.team2Hand = round.team2Hand.getValue().toString();
       switch(round.result)
       {
           case DRAW:
               this.result = JRoundResult.Draw;
               break;
           case NOT_COMPLETE:
               this.result = JRoundResult.NotComplete;
               break;
           case TEAM_1_WON:
               this.result = JRoundResult.Team1Won;
               break;
           case TEAM_2_WON:
               this.result = JRoundResult.Team2Won;
               break;
       }
       this.roundNumber = round.getSequenceNumber();
    }
    
    public void Map(RoundData round)
    {
        switch(round.getTeam1Hand())
        {
            case "0":
                this.team1Hand = "None";
                break;
            case "1":
                this.team1Hand = "Rock";
                break;
            case "2":
                this.team1Hand = "Paper";
                break;
            case "3":
                this.team1Hand = "Scissor";
                break;
            case "4":
                this.team1Hand = "Lizard";
                break;
            case "5":
                this.team1Hand = "Spock";
                break;
        }
        
        switch(round.getTeam2Hand())
        {
            case "0":
                this.team2Hand = "None";
                break;
            case "1":
                this.team2Hand = "Rock";
                break;
            case "2":
                this.team2Hand = "Paper";
                break;
            case "3":
                this.team2Hand = "Scissor";
                break;
            case "4":
                this.team2Hand = "Lizard";
                break;
            case "5":
                this.team2Hand = "Spock";
                break;
        }
        
       switch(round.getResult())
       {
           case "3":
               this.result = JRoundResult.Draw;
               break;
           case "0":
               this.result = JRoundResult.NotComplete;
               break;
           case "1":
               this.result = JRoundResult.Team1Won;
               break;
           case "2":
               this.result = JRoundResult.Team2Won;
               break;
       }
       this.roundNumber = Integer.parseInt(round.getSequenceNumber());
    }

    public String getTeam1Hand() {
        return team1Hand;
    }

    public String getTeam2Hand() {
        return team2Hand;
    }

    public int getRoundNumber() {
        return roundNumber;
    }
    
    public JRoundResult getResult() {
        return result;
    }
}
