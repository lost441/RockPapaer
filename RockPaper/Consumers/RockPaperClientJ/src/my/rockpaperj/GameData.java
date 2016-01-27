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
public class GameData {
    private String id;
    private String teamName1;
    private String teamName2;
    private String gameState;
    private String isComplete;
    private String winningTeam;

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getTeamName1() {
        return teamName1;
    }

    public void setTeamName1(String teamName1) {
        this.teamName1 = teamName1;
    }

    public String getTeamName2() {
        return teamName2;
    }

    public void setTeamName2(String teamName2) {
        this.teamName2 = teamName2;
    }

    public String getGameState() {
        return gameState;
    }

    public void setGameState(String gameState) {
        this.gameState = gameState;
    }

    public String getIsComplete() {
        return isComplete;
    }

    public void setIsComplete(String isComplete) {
        this.isComplete = isComplete;
    }

    public String getWinningTeam() {
        return winningTeam;
    }

    public void setWinningTeam(String winningTeam) {
        this.winningTeam = winningTeam;
    }
    
}
