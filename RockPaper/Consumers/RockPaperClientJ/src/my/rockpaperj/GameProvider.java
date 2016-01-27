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
public class GameProvider implements IGameProvider{

    private String teamId;
    private String teamName;
    private boolean isTeamRegistered;
    private JGame game;
    private boolean useRest;

    public GameProvider(boolean useRest) {
        this.useRest = useRest;
    }

    @Override
    public TeamResult RegisterTeam(String teamName) {

        IGameAdapter adapter;
        
        try
        {
            adapter = AdapterFactory.GetGameAdapter(this.useRest);
        }
        catch(Exception ex)
        {
            TeamResult result = new TeamResult();
            result.setWasSuccessful(false);
            result.setIsRegistered(false);
            result.setErrorReason(ex.getMessage());
            return result;
        }
                
        TeamResult result = adapter.GetTeam(teamName);
        
        if(result.getWasSuccessful())
        {
            if(result.getIsRegistered())
            {
                return result;
            }
            else
            {
                return adapter.RegisterTeam(teamName);
            }
        }
        else
        {
            return result;
        }
        
    }
    
    @Override
    public JGame JoinGame(String teamId, boolean useSimulator) {
        IGameAdapter adapter;
        
        JGame result = new JGame();
        result.setWasSuccessful(false);
        result.setIsInGame(false);
            
        try
        {
            adapter = AdapterFactory.GetGameAdapter(this.useRest);
        }
        catch(Exception ex)
        {
            result.setErrorReason(ex.getMessage());
            return result;
        }
        
        GetNextAvailableGameOutcome outcome = adapter.GetNextAvailableGame(teamId, useSimulator);
        if(outcome.isWasSuccessful() && outcome.getGameId() != null)
        {
            JGame gameDetails = adapter.GetGameById(outcome.getGameId());
            return gameDetails;
        }
        else
        {
            result.setErrorReason("No game available");
        }
        
        return game;
    }
    
    @Override
    public JGame UpdateGameState(String gameId) {
        IGameAdapter adapter;
        
        JGame result = new JGame();
        result.setWasSuccessful(false);
        result.setIsInGame(false);
            
        try
        {
            adapter = AdapterFactory.GetGameAdapter(this.useRest);
        }
        catch(Exception ex)
        {
            result.setErrorReason(ex.getMessage());
            return result;
        }
        JGame gameDetails = adapter.GetGameById(gameId);
        return gameDetails;
    }

    @Override
    public boolean IsItMyTurn(String gameId, String teamId) {
        IGameAdapter adapter;
        adapter = AdapterFactory.GetGameAdapter(this.useRest);
        
        try
        {
            return adapter.IsItMyTurn(gameId, teamId);
        }
        catch(Exception ex)
        {
            return false; //Might need work to properly deal with exception in place of just hiding it.
        }
    }

    @Override
    public List<JRound> PlayHand(String gameId, String teamId) throws ApplicationException
    {
        IGameAdapter adapter;
        adapter = AdapterFactory.GetGameAdapter(this.useRest);
        JHand hand = HandGenerator.GenerateHand();
        Outcome result = adapter.PlayHand(gameId, teamId, hand);
        if(result.isWasSuccessful())
        {
            return adapter.GetRoundsByGameId(gameId);
        }
        else
        {
            throw new ApplicationException(result.getErrorReason());
        }
    }

    @Override
    public void GetGameStatus(String gameId) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
}
