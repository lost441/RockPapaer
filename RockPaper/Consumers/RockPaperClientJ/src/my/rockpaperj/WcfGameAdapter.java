/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package my.rockpaperj;

import java.util.ArrayList;
import java.util.List;
import java.util.ListIterator;
import javax.xml.ws.BindingProvider;

/**
 *
 * @author kmarais
 */
public class WcfGameAdapter implements IGameAdapter {

    @Override
    public List<JRound> GetRoundsByGameId(String gameId) {
        List<JRound> result = new ArrayList<JRound>();
        
        //YOUR CODE HERE
       
       return result;
        
    }

    @Override
    public Outcome PlayHand(String gameId, String teamId, JHand hand) {
        ResponseItemOfOperationOutcomew4XXQMJA response;
        Outcome outcome = new Outcome();
        outcome.setWasSuccessful(false);
        
        Hand handToPlay = Hand.NONE;
        switch(hand)
        {
            case Lizard:
                handToPlay = Hand.LIZARD;
                break;
            case Paper:
                handToPlay = Hand.PAPER;
                break;
            case Rock:
                handToPlay = Hand.ROCK;
                break;
            case Scissor:
                handToPlay = Hand.SCISSOR;
                break;
            case Spock:
                handToPlay = Hand.SPOCK;
                break;
        }
        response = this.playHand(gameId, teamId, handToPlay);
        if(response.isIsSuccessfull())
        {
            outcome.setWasSuccessful(true);
        }
        else
        {
            outcome.setErrorReason(response.resultDescription.getValue());
        }
        return outcome;
    }

    @Override
    public boolean IsItMyTurn(String gameId, String teamId) throws ApplicationException
    {
        ResponseItemOfboolean response;
        response = this.isItMyTurn(gameId, teamId);
        if(response.isIsSuccessfull())
        {
            return response.data.booleanValue();
        }
        else
        {
            throw new ApplicationException(response.resultDescription.getValue());
        }
    }

    @Override
    public JGame GetGameById(String gameId) {
        JGame game = new JGame();
        game.setIsInGame(false);
        game.setWasSuccessful(false);
        
        ResponseItemOfGameRcKUQpc9 response;
        try
        {
            response = this.getGamebyGameId(gameId);
        }
        catch(Exception ex)
        {
            game.setErrorReason(ex.getMessage());
            return game;
        }
        
        if(response.isIsSuccessfull())
        {
            game.setIsInGame(true);
            game.setWasSuccessful(true);
            game.Map(response);
            return game;
        }
        else
        {
            game.setErrorReason("Unable to get game.");
            return game;
        }
    }

    @Override
    public GetNextAvailableGameOutcome GetNextAvailableGame(String teamID, boolean useSimulator) {
        GetNextAvailableGameOutcome outcome = new GetNextAvailableGameOutcome();
        outcome.setWasSuccessful(false);
        
        ResponseItemOfguid response;
        try
        {
            response = this.getNextAvailableGame(teamID, useSimulator);
        }
        catch(Exception ex)
        {
            outcome.setErrorReason(ex.getMessage());
            return outcome;
        }
        
        if(response.isIsSuccessfull())
        {
            outcome.setWasSuccessful(true);
            outcome.setGameId(response.getData());
        }
        else
        {
            outcome.setErrorReason(response.data);
        }
        
        return outcome;
    }

    @Override
    public TeamResult GetTeam(String teamName) {
        ResponseItemOfTeams5XbATXb response;
        try
        {
            response = this.getTeamByTeamName(teamName);
        }
        catch(Exception ex)
        {
            TeamResult result = new TeamResult();
            result.setWasSuccessful(false);
            result.setErrorReason(ex.getMessage());
            result.setIsRegistered(false);
            return result;
        }
        
        if(response.isSuccessfull)
        {
            Team team = response.data.getValue();
            if(team != null)
            {
                TeamResult result = new TeamResult();
                result.setId(team.getId());
                result.setTeamName(team.getTeamName().toString());
                result.setWasSuccessful(true);
                result.setIsRegistered(true);
                return result;
            }
            else
            {
                TeamResult result = new TeamResult();
                result.setWasSuccessful(true);
                result.setIsRegistered(false);
                result.setErrorReason("No team by that name exists.");
                return result;
            }
        }
        else
        {
            TeamResult result = new TeamResult();
            result.setWasSuccessful(false);
            result.setIsRegistered(false);
            result.setErrorReason(response.getResultDescription().toString());
            return result;
        }
    }
    
    @Override
    public TeamResult RegisterTeam(String teamName) {
        
        ResponseItemOfTeams5XbATXb response;
        try
        {
            response = this.registerTeam(teamName);
        }
        catch(Exception ex)
        {
            TeamResult result = new TeamResult();
            result.setWasSuccessful(false);
            result.setIsRegistered(false);
            result.setErrorReason(ex.getMessage());
            return result;
        }

        if(response.isSuccessfull)
        {
            Team team = response.data.getValue();
            if(team != null)
            {
                TeamResult result = new TeamResult();
                result.setId(team.getId());
                result.setTeamName(team.getTeamName().toString());
                result.setWasSuccessful(true);
                result.setIsRegistered(true);
                return result;
            }
            else
            {
                TeamResult result = new TeamResult();
                result.setWasSuccessful(true);
                result.setIsRegistered(false);
                result.setErrorReason("Unable to register team.");
                return result;
            }
        }
        else
        {
            TeamResult result = new TeamResult();
            result.setWasSuccessful(false);
            result.setIsRegistered(false);
            result.setErrorReason(response.getResultDescription().toString());
            return result;
        }
    }

    private ArrayOfRound getCompletedRoundByGameId(java.lang.String gameId) {
        my.rockpaperj.RockPaperService service = new my.rockpaperj.RockPaperService();
        my.rockpaperj.IRockPaperService port = service.getBasicHttpBindingIRockPaperService();
        BindingProvider bindingProvider = (BindingProvider) port;
        bindingProvider.getRequestContext().put(
        BindingProvider.ENDPOINT_ADDRESS_PROPERTY, String.format("http://%1$s/services/RockPaperService.svc", Configuration.getUrlRoot()));
        return port.getCompletedRoundByGameId(gameId);
    }

    private ResponseItemOfGameRcKUQpc9 getGamebyGameId(java.lang.String gameId) {
        my.rockpaperj.RockPaperService service = new my.rockpaperj.RockPaperService();
        
        my.rockpaperj.IRockPaperService port = service.getBasicHttpBindingIRockPaperService();
        BindingProvider bindingProvider = (BindingProvider) port;
        bindingProvider.getRequestContext().put(
        BindingProvider.ENDPOINT_ADDRESS_PROPERTY, String.format("http://%1$s/services/RockPaperService.svc", Configuration.getUrlRoot()));
        return port.getGamebyGameId(gameId);
    }

    private ResponseItemOfguid getNextAvailableGame(java.lang.String teamId, java.lang.Boolean useSimulator) {
        my.rockpaperj.RockPaperService service = new my.rockpaperj.RockPaperService();
        my.rockpaperj.IRockPaperService port = service.getBasicHttpBindingIRockPaperService();
        BindingProvider bindingProvider = (BindingProvider) port;
        bindingProvider.getRequestContext().put(
        BindingProvider.ENDPOINT_ADDRESS_PROPERTY, String.format("http://%1$s/services/RockPaperService.svc", Configuration.getUrlRoot()));
        return port.getNextAvailableGame(teamId, useSimulator);
    }

    private ResponseItemOfTeams5XbATXb getTeamByTeamName(java.lang.String teamName) {
        
        my.rockpaperj.RockPaperService service = new my.rockpaperj.RockPaperService();
        my.rockpaperj.IRockPaperService port = service.getBasicHttpBindingIRockPaperService();
        BindingProvider bindingProvider = (BindingProvider) port;
        bindingProvider.getRequestContext().put(
        BindingProvider.ENDPOINT_ADDRESS_PROPERTY, String.format("http://%1$s/services/RockPaperService.svc", Configuration.getUrlRoot()));
        return port.getTeamByTeamName(teamName);
    }

    private ResponseItemOfboolean isItMyTurn(java.lang.String gameId, java.lang.String teamId) {
        my.rockpaperj.RockPaperService service = new my.rockpaperj.RockPaperService();
        my.rockpaperj.IRockPaperService port = service.getBasicHttpBindingIRockPaperService();
        BindingProvider bindingProvider = (BindingProvider) port;
        bindingProvider.getRequestContext().put(
        BindingProvider.ENDPOINT_ADDRESS_PROPERTY, String.format("http://%1$s/services/RockPaperService.svc", Configuration.getUrlRoot()));
        return port.isItMyTurn(gameId, teamId);
    }

    private ResponseItemOfOperationOutcomew4XXQMJA playHand(java.lang.String gameId, java.lang.String teamId, my.rockpaperj.Hand hand) {
        my.rockpaperj.RockPaperService service = new my.rockpaperj.RockPaperService();
        my.rockpaperj.IRockPaperService port = service.getBasicHttpBindingIRockPaperService();
        BindingProvider bindingProvider = (BindingProvider) port;
        bindingProvider.getRequestContext().put(
        BindingProvider.ENDPOINT_ADDRESS_PROPERTY, String.format("http://%1$s/services/RockPaperService.svc", Configuration.getUrlRoot()));
        return port.playHand(gameId, teamId, hand);
    }

    private static ResponseItemOfTeams5XbATXb registerTeam(java.lang.String teamName) {
        my.rockpaperj.RockPaperService service = new my.rockpaperj.RockPaperService();
        my.rockpaperj.IRockPaperService port = service.getBasicHttpBindingIRockPaperService();
        BindingProvider bindingProvider = (BindingProvider) port;
        bindingProvider.getRequestContext().put(
        BindingProvider.ENDPOINT_ADDRESS_PROPERTY, String.format("http://%1$s/services/RockPaperService.svc", Configuration.getUrlRoot()));
        return port.registerTeam(teamName);
    }
}
