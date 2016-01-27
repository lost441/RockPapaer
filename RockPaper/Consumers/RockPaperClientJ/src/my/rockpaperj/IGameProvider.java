/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package my.rockpaperj;

import java.util.List;

/**
 *
 * @author kmarais
 */
public interface IGameProvider {
    TeamResult RegisterTeam(String teamName);
    JGame JoinGame(String teamId, boolean useSimulator);
    JGame UpdateGameState(String gameId);
    boolean IsItMyTurn(String gameId, String teamId);
    List<JRound> PlayHand(String gameId, String teamId) throws ApplicationException;
    void GetGameStatus(String gameId);
}
