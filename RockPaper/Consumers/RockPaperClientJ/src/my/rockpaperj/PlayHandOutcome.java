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
public class PlayHandOutcome {
    private boolean data;
    private String isSuccessfull;
    private String resultCode;
    private String resultDescription;
    private String[] errors;

    public boolean isData() {
        return data;
    }

    public void setData(boolean data) {
        this.data = data;
    }

    public String getIsSuccessfull() {
        return isSuccessfull;
    }

    public void setIsSuccessfull(String isSuccessfull) {
        this.isSuccessfull = isSuccessfull;
    }

    public String getResultCode() {
        return resultCode;
    }

    public void setResultCode(String resultCode) {
        this.resultCode = resultCode;
    }

    public String getResultDescription() {
        return resultDescription;
    }

    public void setResultDescription(String resultDescription) {
        this.resultDescription = resultDescription;
    }

    public String[] getErrors() {
        return errors;
    }

    public void setErrors(String[] errors) {
        this.errors = errors;
    }
}
