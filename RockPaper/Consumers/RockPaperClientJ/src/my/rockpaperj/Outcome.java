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
public class Outcome {
    private boolean wasSuccessful;
    private String ErrorReason;

    public boolean isWasSuccessful() {
        return wasSuccessful;
    }

    public void setWasSuccessful(boolean wasSuccessful) {
        this.wasSuccessful = wasSuccessful;
    }

    public String getErrorReason() {
        return ErrorReason;
    }

    public void setErrorReason(String ErrorReason) {
        this.ErrorReason = ErrorReason;
    }
}
