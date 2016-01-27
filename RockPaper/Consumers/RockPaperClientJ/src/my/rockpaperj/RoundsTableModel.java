/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package my.rockpaperj;

import java.util.List;
import javax.swing.table.AbstractTableModel;

/**
 *
 * @author KMarais
 */
public class RoundsTableModel extends AbstractTableModel{

    @Override
    public int getRowCount() {
        return rounds.size();
    }

    @Override
    public int getColumnCount() {
        return columns.length;
    }
    private List<RoundDisplay> rounds ;
    private String[] columns ; 
    
    public RoundsTableModel(List<RoundDisplay> roundList)
    {
        super();
        this.rounds = roundList;
        columns = new String[]{"Round","My Hand","Opponent's Hand", "Winning Team"};
    }
    
    public Object getValueAt(int row, int col) {
    RoundDisplay round = rounds.get(row);
    switch(col) {
      case 0: return round.getRound();
      case 1: return round.getMyHand();
      case 2: return round.getOpponentHand();
      case 3: return round.getOutcome();
      default: return null;
    }
  }
    
    public String getColumnName(int col) {
    return columns[col] ;
  }
}
