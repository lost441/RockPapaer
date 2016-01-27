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
public interface IGameAdapter {
    TeamResult GetTeam(String teamName);
    TeamResult RegisterTeam(String teamName);
    GetNextAvailableGameOutcome GetNextAvailableGame(String teamID, boolean useSimulator);
    JGame GetGameById(String gameId);
    boolean IsItMyTurn(String gameId, String teamId) throws ApplicationException;
    Outcome PlayHand(String gameId, String teamId, JHand hand); 
    List<JRound> GetRoundsByGameId(String gameId) throws ApplicationException;;
}
