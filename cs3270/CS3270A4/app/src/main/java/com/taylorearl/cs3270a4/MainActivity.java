package com.taylorearl.cs3270a4;

import android.annotation.TargetApi;
import java.math.BigDecimal;

import android.content.SharedPreferences;
import android.os.Build;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

import static java.lang.Double.parseDouble;

public class MainActivity extends AppCompatActivity {

    double seekValue = 0;
    double itemTotals = 0;
    double totalAmount = 0;
    double rate = 0;
    double taxAmount = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        //init();
        //saveState();
        setContentView(R.layout.activity_main);
        getSupportFragmentManager().beginTransaction()
                .replace(R.id.top, new TotalsFragment(), "TO")
                .commit();
        getSupportFragmentManager().beginTransaction()
                .replace(R.id.middle, new TaxFragment(), "MD")
                .commit();
        getSupportFragmentManager().beginTransaction()
                .replace(R.id.bottom, new ItemsFragment(), "BO")
                .commit();
    }

    @Override
    protected void onStart() {
        super.onStart();
        restoreState();
    }

    public void init(){

        seekValue = 0;
        itemTotals = 0;
        totalAmount = 0;
        rate = 0;
        taxAmount = 0;
    }

    private void updateTaxes(){
        TaxFragment frag = (TaxFragment) getSupportFragmentManager().findFragmentByTag("MD");
        rate = seekValue/4;
        BigDecimal taxRate = new BigDecimal(rate);
        BigDecimal bigSeekValue = new BigDecimal(seekValue);
        BigDecimal four = new BigDecimal(4);
        taxRate = bigSeekValue.divide(four);
        BigDecimal oneHundred = new BigDecimal(100);
        BigDecimal bigTaxAmount = new BigDecimal(1);
        BigDecimal bigItemTotal = new BigDecimal(itemTotals);
        bigTaxAmount = taxRate.divide(oneHundred);
        bigTaxAmount = bigTaxAmount.multiply(bigItemTotal);
        taxAmount = itemTotals * (rate/100);
        if(frag != null){
            frag.updateDisplay(taxRate, bigTaxAmount);
        }

    }

    private void updateTotal(){
        TotalsFragment frag = (TotalsFragment) getSupportFragmentManager().findFragmentByTag("TO");
        BigDecimal bigItemTotal = new BigDecimal(itemTotals);
        BigDecimal bigTaxAmount = new BigDecimal(taxAmount);
        BigDecimal bigTotalAmount = new BigDecimal(totalAmount);
        bigTotalAmount = bigItemTotal.add(bigTaxAmount);
        totalAmount = itemTotals + taxAmount;
        if(frag != null){
            frag.updateDisplay(bigTotalAmount);
        }
    }

    public void saveState(){
        SharedPreferences sp = getPreferences((MODE_PRIVATE));
        SharedPreferences.Editor spEditor = sp.edit();
        spEditor.putString("seekValue", Double.toString(seekValue));
        spEditor.putString("itemTotals", Double.toString(itemTotals));
        spEditor.putString("totalAmount", Double.toString(totalAmount));
        spEditor.putString("rate", Double.toString(rate));
        spEditor.putString("taxAmount", Double.toString(taxAmount));
        spEditor.commit();
    }

    public void restoreState(){
        SharedPreferences sp = getPreferences((MODE_PRIVATE));
        seekValue = parseDouble(sp.getString("seekValue","0.0"));
        itemTotals = parseDouble(sp.getString("itemTotals","0.0"));
        totalAmount = parseDouble(sp.getString("totalAmount","0.0"));
        rate = parseDouble(sp.getString("rate","0.0"));
        taxAmount = parseDouble(sp.getString("taxAmount","0.0"));
    }

    public void setSeekValue(int value){
        seekValue = (double)value;
        updateTaxes();
        updateTotal();
        //saveState();
    }

    public void setItemTotals(double inputAmount){
        itemTotals = inputAmount;
        updateTaxes();
        updateTotal();
        //saveState();
    }

    @Override
    protected void onPause() {
        super.onPause();
        saveState();
    }
}
