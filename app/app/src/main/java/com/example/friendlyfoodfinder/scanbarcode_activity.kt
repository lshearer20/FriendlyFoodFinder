package com.example.friendlyfoodfinder

import android.content.Intent
import android.os.Bundle
import android.os.StrictMode
import android.widget.Toast
import com.google.android.material.snackbar.Snackbar
import androidx.appcompat.app.AppCompatActivity;
import com.google.zxing.integration.android.IntentIntegrator

import kotlinx.android.synthetic.main.activity_scanbarcode_activity.*
import kotlinx.android.synthetic.main.content_create_user.*
import kotlinx.android.synthetic.main.content_main.*
import kotlinx.android.synthetic.main.content_scanbarcode_activity.*
import java.net.URL

class scanbarcode_activity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_scanbarcode_activity)
        setSupportActionBar(toolbar)

        scan_button.setOnClickListener { view ->
            Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
                .setAction("Action", null).show()
        }

        //////////////// scan button stuff  ////////////////////
        scan_button.setOnClickListener {
            val scanner = IntentIntegrator(this)
            scanner.initiateScan()
        }
    }
    ////////////////////Scan button stuff ///////////////////////////////
    override fun onActivityResult(requestCode: Int, resultCode: Int, data: Intent?) {
        val result = IntentIntegrator.parseActivityResult(requestCode, resultCode, data)
        if (result != null) {
            if (result.contents == null) {
                Toast.makeText(this, "Cancelled", Toast.LENGTH_LONG).show()
            } else {
                val policy = StrictMode.ThreadPolicy.Builder().permitAll().build()
                StrictMode.setThreadPolicy(policy)
                val queryResult = URL("http://friendly-food-finder.azurewebsites.net/api/nutrition/"+result.contents).readText()
                if(queryResult != "null") {
                    val splitQuery = queryResult.subSequence(1, queryResult.length - 1).split("|")
                    val sharedPreferences = getApplicationContext().getSharedPreferences("Settings", 0)
                    val alergiesList = sharedPreferences.getString("alergiesList", " water, sugar").toUpperCase()
                    val separated = alergiesList.split(",")
                    val warningText = StringBuilder()
                    warningText.append("WARNING CONTAINS: ")
                    for (item in separated) {
                        if (splitQuery[0].toUpperCase().contains(item)) {
                            warningText.append(item + ",")
                        }
                    }
                    if (warningText.toString() != "WARNING CONTAINS: ") {
                        Ingredients.text = splitQuery[0]
                        name.text = splitQuery[1]
                        flaggedAlergies.text = warningText.substring(0, warningText.length - 1)
                    } else {
                        Ingredients.text = splitQuery[0]
                        name.text = splitQuery[1]
                        flaggedAlergies.text = "No warnings!"
                    }
                }
                else
                {
                    Ingredients.text = ""
                    name.text = "Item not found in the database...."
                    flaggedAlergies.text = ""
                }

            }
        } else {
            super.onActivityResult(requestCode, resultCode, data)
        } // barcode # is stored in result.contents !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    }
}
