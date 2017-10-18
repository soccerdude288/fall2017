package com.example.taylor.cs3270a8;


import android.app.AlertDialog;
import android.app.Dialog;
import android.content.DialogInterface;
import android.os.Bundle;
import android.support.v4.app.DialogFragment;
import android.support.v4.app.Fragment;


/**
 * A simple {@link Fragment} subclass.
 */
public class DeleteConfirmDialogFragment extends DialogFragment {


    public DeleteConfirmDialogFragment() {
        // Required empty public constructor
    }

    @Override
    public Dialog onCreateDialog(Bundle savedInstanceState) {
        AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
        Dialog dialog = builder.setMessage("This will permanently delete the course.")
                .setTitle("Are you sure?")
                .setNegativeButton("Cancel", new DialogInterface.OnClickListener(){
                    public void onClick(DialogInterface dialog, int id){
                        MainActivity ma = (MainActivity) getActivity();
                    }
                })
                .setPositiveButton("Delete",new DialogInterface.OnClickListener(){
                    public void onClick(DialogInterface dialog, int id){
                        MainActivity ma = (MainActivity) getActivity();
                        ma.deleteRecord();
                        ma.goToList();
                    }
                }).create();
        return dialog;
    }
}
