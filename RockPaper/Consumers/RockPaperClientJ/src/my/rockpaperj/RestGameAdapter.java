/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package my.rockpaperj;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;



/**
 *
 * @author KMarais
 */
public class RestGameAdapter implements IGameAdapter {
    
    @Override
    public TeamResult GetTeam(String teamName) {
        TeamResult result = new TeamResult();
        result.setWasSuccessful(false);
        result.setIsRegistered(false);
        
        try
        {
            URL url = new URL(String.format("http://%2$s/api/V01/teams?teamName=%1$s", teamName, Configuration.getUrlRoot()));
            String userPassword = "paym8user:password";
            String encoding = new sun.misc.BASE64Encoder().encode(userPassword.getBytes());
            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            conn.setRequestProperty("Authorization", "Basic " + encoding);
            
            conn.setRequestMethod("GET");
            conn.setRequestProperty("Accept", "application/xml");
 
            if (conn.getResponseCode() != 200)
            {
                result.setErrorReason(String.format("Remote server returned %1$s", Integer.toString(conn.getResponseCode())));
                return result;
            }
 
            BufferedReader br = new BufferedReader(new InputStreamReader((conn.getInputStream())));
            StringBuilder sb = new StringBuilder();
            String line = br.readLine();
            
            while(line != null)
            {   sb.append(line);
                line = br.readLine();
            }
            String apiOutput = sb.toString();
            conn.disconnect();
 
            Gson gson = new GsonBuilder().create();
            RTeam team = gson.fromJson(apiOutput, RTeam.class);
            
            if (team != null)
            {
                TeamData[] data = team.getData();
                if(data.length > 0 && data[0] != null)
                {
                    result.setId(data[0].getId());
                    result.setTeamName(data[0].getTeamName());
                }
                else
                {
                    result.setIsRegistered(false);
                }
                result.setWasSuccessful(true);
            }
        }
        catch (MalformedURLException e) 
        {
            result.setErrorReason(e.getMessage());
        } 
        catch (IOException e) 
        {
            result.setErrorReason(e.getMessage());
        } 
        catch(Exception ex)
        {
            result.setErrorReason(ex.getMessage());
        }
        return result;
    }

    @Override
    public TeamResult RegisterTeam(String teamName) {
        TeamResult result = new TeamResult();
        result.setWasSuccessful(false);
        result.setIsRegistered(false);
        
        try
        {
            URL url = new URL(String.format("http://%1$s/api/V01/teams",Configuration.getUrlRoot()));
            String userPassword = "paym8user:password";
            String encoding = new sun.misc.BASE64Encoder().encode(userPassword.getBytes());
            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            conn.setRequestProperty("Authorization", "Basic " + encoding);
            
            conn.setRequestMethod("POST");
            conn.setRequestProperty("Accept", "application/xml");
            conn.setRequestProperty("Content-Type", "application/json");
            conn.setDoOutput(true);
            OutputStreamWriter out = new OutputStreamWriter(
                conn.getOutputStream());
            
            Gson gsonb = new GsonBuilder().create();
            TeamData resource = new TeamData();
            resource.setTeamName(teamName);
            out.write(gsonb.toJson(resource));
            out.close();
            
            if (conn.getResponseCode() != 200)
            {
                result.setErrorReason(String.format("Remote server returned %1$s", Integer.toString(conn.getResponseCode())));
                return result;
            }
 
            BufferedReader br = new BufferedReader(new InputStreamReader((conn.getInputStream())));
            StringBuilder sb = new StringBuilder();
            String line = br.readLine();
            
            while(line != null)
            {   sb.append(line);
                line = br.readLine();
            }
            String apiOutput = sb.toString();
            conn.disconnect();
 
            Gson gson = new GsonBuilder().create();
            TeamResponseItem team = gson.fromJson(apiOutput, TeamResponseItem.class);
            
            if (team != null)
            {
                TeamData data = team.getData();
                if(data != null)
                {
                    result.setId(data.getId());
                    result.setTeamName(data.getTeamName());
                    result.setIsRegistered(true);
                }
                result.setIsRegistered(true);
                result.setWasSuccessful(true);
            }
        }
        catch (MalformedURLException e) 
        {
            result.setErrorReason(e.getMessage());
        } 
        catch (IOException e) 
        {
            result.setErrorReason(e.getMessage());
        } 
        catch(Exception ex)
        {
            result.setErrorReason(ex.getMessage());
        }
        return result;
    }

    @Override
    public GetNextAvailableGameOutcome GetNextAvailableGame(String teamID, boolean useSimulator) {
        GetNextAvailableGameOutcome result = new GetNextAvailableGameOutcome();
        result.setWasSuccessful(false);
        
        try
        {
            URL url = new URL(String.format("http://%3$s/api/V01/games?isActive=true&teamId=%1$s&playAgainstSimulator=%2$s", teamID, useSimulator, Configuration.getUrlRoot()));
            String userPassword = "paym8user:password";
            String encoding = new sun.misc.BASE64Encoder().encode(userPassword.getBytes());
            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            conn.setRequestProperty("Authorization", "Basic " + encoding);
            
            conn.setRequestMethod("GET");
            conn.setRequestProperty("Accept", "application/xml");
 
            if (conn.getResponseCode() != 200)
            {
                result.setErrorReason(String.format("Remote server returned %1$s", Integer.toString(conn.getResponseCode())));
                return result;
            }
 
            BufferedReader br = new BufferedReader(new InputStreamReader((conn.getInputStream())));
            StringBuilder sb = new StringBuilder();
            String line = br.readLine();
            
            while(line != null)
            {   sb.append(line);
                line = br.readLine();
            }
            String apiOutput = sb.toString();
            conn.disconnect();
 
            Gson gson = new GsonBuilder().create();
            GameDataOutcome gameData = gson.fromJson(apiOutput, GameDataOutcome.class);
            
            if (gameData != null)
            {
                GameData[] data = gameData.getData();
                if(data.length > 0 && data[0] != null)
                {
                    result.setGameId(data[0].getId());
                    result.setWasSuccessful(true);
                }
            }
        }
        catch (MalformedURLException e) 
        {
            result.setErrorReason(e.getMessage());
        } 
        catch (IOException e) 
        {
            result.setErrorReason(e.getMessage());
        } 
        catch(Exception ex)
        {
            result.setErrorReason(ex.getMessage());
        }
        return result;
    }

    @Override
    public JGame GetGameById(String gameId) {
        JGame result = new JGame();
        result.setWasSuccessful(false);
        result.setIsInGame(false);
        
        try
        {
            URL url = new URL(String.format("http://%2$s/api/V01/games/%1$s", gameId,Configuration.getUrlRoot()));
            String userPassword = "paym8user:password";
            String encoding = new sun.misc.BASE64Encoder().encode(userPassword.getBytes());
            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            conn.setRequestProperty("Authorization", "Basic " + encoding);
            
            conn.setRequestMethod("GET");
            conn.setRequestProperty("Accept", "application/xml");
 
            if (conn.getResponseCode() != 200)
            {
                result.setErrorReason(String.format("Remote server returned %1$s", Integer.toString(conn.getResponseCode())));
                return result;
            }
 
            BufferedReader br = new BufferedReader(new InputStreamReader((conn.getInputStream())));
            StringBuilder sb = new StringBuilder();
            String line = br.readLine();
            
            while(line != null)
            {   sb.append(line);
                line = br.readLine();
            }
            String apiOutput = sb.toString();
            conn.disconnect();
 
            Gson gson = new GsonBuilder().create();
            GameDataResult gameData = gson.fromJson(apiOutput, GameDataResult.class);
            
            if (gameData != null)
            {
                GameData data = gameData.getData();
                if(data != null)
                {
                    switch(data.getGameState())
                    {
                        case "0":
                            result.setState(JGameState.WaitingForPlayers);
                            break;
                        case "1":
                            result.setState(JGameState.Player1Hand);
                            break;
                        case "2":
                            result.setState(JGameState.Player2Hand);
                            break;
                        case "3":
                            result.setState(JGameState.Complete);
                            break;
                    }
                    result.setId(data.getId());
                    result.setIsComplete(data.getGameState()=="3");
                    result.setIsInGame(true);
                    result.setTeamName1(data.getTeamName1());
                    result.setTeamName2(data.getTeamName2());
                    result.setWasSuccessful(true);
                    result.setWinningTeam(data.getWinningTeam());
                }
            }
        }
        catch (MalformedURLException e) 
        {
            result.setErrorReason(e.getMessage());
        } 
        catch (IOException e) 
        {
            result.setErrorReason(e.getMessage());
        } 
        catch(Exception ex)
        {
            result.setErrorReason(ex.getMessage());
        }
        return result;
    }

    @Override
    public boolean IsItMyTurn(String gameId, String teamId) throws ApplicationException {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public Outcome PlayHand(String gameId, String teamId, JHand hand) {
        Outcome result = new Outcome();;
        result.setWasSuccessful(false);
        try
        {
            URL url = new URL(String.format("http://%4$s/api/V01/games/PlayHand?gameId=%1$s&teamId=%2$s&Hand=%3$s", gameId, teamId, hand.toString(), Configuration.getUrlRoot()));
            String userPassword = "paym8user:password";
            String encoding = new sun.misc.BASE64Encoder().encode(userPassword.getBytes());
            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            conn.setRequestProperty("Authorization", "Basic " + encoding);
            
            conn.setRequestMethod("GET");
            conn.setRequestProperty("Accept", "application/xml");
 
            if (conn.getResponseCode() != 200)
            {
                result.setErrorReason(String.format("Remote server returned %1$s", Integer.toString(conn.getResponseCode())));
            }
 
            BufferedReader br = new BufferedReader(new InputStreamReader((conn.getInputStream())));
            StringBuilder sb = new StringBuilder();
            String line = br.readLine();
            
            while(line != null)
            {   sb.append(line);
                line = br.readLine();
            }
            String apiOutput = sb.toString();
            conn.disconnect();
 
            Gson gson = new GsonBuilder().create();
            PlayHandOutcome outcome = gson.fromJson(apiOutput, PlayHandOutcome.class);
            
            if (outcome != null && outcome.getIsSuccessfull() == "true" && outcome.isData())
            {
                result.setWasSuccessful(true);
            }
        }
        catch (MalformedURLException e) 
        {
            result.setErrorReason(e.getMessage());
        } 
        catch (IOException e) 
        {
            result.setErrorReason(e.getMessage());
        } 
        catch(Exception ex)
        {
            result.setErrorReason(ex.getMessage());
        }
        return result;
    }

    @Override
    public List<JRound> GetRoundsByGameId(String gameId) throws ApplicationException {
        List<JRound> result = new ArrayList<JRound>();;
        
        //YOUR CODE HERE TO GET ROUND HISTORY
        return result;
    }
}
