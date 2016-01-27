/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package my.rockpaperj;

/**
 *
 * @author KMarais
 */
public class RoundData {
    private String id;
    private String gameId;
    private String team1Hand;
    private String team2Hand;
    private String result;
    private String sequenceNumber;

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getGameId() {
        return gameId;
    }

    public void setGameId(String gameId) {
        this.gameId = gameId;
    }

    public String getTeam1Hand() {
        return team1Hand;
    }

    public void setTeam1Hand(String team1Hand) {
        this.team1Hand = team1Hand;
    }

    public String getTeam2Hand() {
        return team2Hand;
    }

    public void setTeam2Hand(String team2Hand) {
        this.team2Hand = team2Hand;
    }

    public String getResult() {
        return result;
    }

    public void setResult(String result) {
        this.result = result;
    }

    public String getSequenceNumber() {
        return sequenceNumber;
    }

    public void setSequenceNumber(String sequenceNumber) {
        this.sequenceNumber = sequenceNumber;
    }
}
