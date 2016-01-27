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
public class TeamResult {
    private boolean wasSuccessful;
    private String errorReason;
    private String id;
    private String teamName;
    private boolean isRegistered;
    
    public void setIsRegistered(boolean value)
    {
        this.isRegistered = value;
    }
    
    public boolean getIsRegistered()
    {
        return this.isRegistered;
    }
    
    public void setWasSuccessful(boolean value)
    {
        this.wasSuccessful = value;
    }
    
    public boolean getWasSuccessful()
    {
        return this.wasSuccessful;
    }
    
    public void setErrorReason(String value)
    {
        this.errorReason = value;
    }
    
    public String getErrorReason()
    {
        return this.errorReason;
    }
    
    public void setId(String id)
    {
        this.id = id;
    }
    
    public String getId()
    {
        return this.id;
    }
    
    public void setTeamName(String teamName)
    {
        this.teamName = teamName;
    }
    
    public String getTeamName()
    {
        return this.teamName;
    } 
}
