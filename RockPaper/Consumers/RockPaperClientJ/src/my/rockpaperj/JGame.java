/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package my.rockpaperj;

import java.util.UUID;

/**
 *
 * @author kmarais
 */
public class JGame {
    private String teamName1;
    private String teamName2;
    private String id;
    private JGameState state;
    private boolean isComplete;
    private String winningTeam;
    private boolean isInGame;
    private String ErrorReason;
    private boolean WasSuccessful;

    public void Map(ResponseItemOfGameRcKUQpc9 response)
    {
        Game game = response.getData().getValue();
        this.teamName1 = game.getTeamName1().getValue();
        this.teamName2 = game.getTeamName2().getValue();
        this.winningTeam = game.getWinningTeam().getValue();
        this.id = game.getId();
        
        GameState state = game.getGameState();
        this.isComplete = (state == GameState.COMPLETE);
        switch(state)
        {
            case COMPLETE:
                this.state = JGameState.Complete;
                break;
            case PLAYER_1_HAND:
                this.state = JGameState.Player1Hand;
                break;
            case PLAYER_2_HAND:
                this.state = JGameState.Player2Hand;
                break;
            case WAITING_FOR_PLAYERS:
                this.state = JGameState.WaitingForPlayers;
                break;
        }
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

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public JGameState getState() {
        return state;
    }

    public void setState(JGameState state) {
        this.state = state;
    }

    public boolean isIsComplete() {
        return isComplete;
    }

    public void setIsComplete(boolean isComplete) {
        this.isComplete = isComplete;
    }

    public String getWinningTeam() {
        return winningTeam;
    }

    public void setWinningTeam(String winningTeam) {
        this.winningTeam = winningTeam;
    }

    public boolean isIsInGame() {
        return isInGame;
    }

    public void setIsInGame(boolean isInGame) {
        this.isInGame = isInGame;
    }

    public String getErrorReason() {
        return ErrorReason;
    }

    public void setErrorReason(String ErrorReason) {
        this.ErrorReason = ErrorReason;
    }

    public boolean isWasSuccessful() {
        return WasSuccessful;
    }

    public void setWasSuccessful(boolean WasSuccessful) {
        this.WasSuccessful = WasSuccessful;
    }
    
    

}


