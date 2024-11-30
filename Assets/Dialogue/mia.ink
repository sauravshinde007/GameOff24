INCLUDE globals.ink

{isTalked_mia == false : -> main_mia | -> already_chose_mia}

=== main_mia ===  
You meet Mia, a tech dealer operating a stall near the nightclub.  

+ [“I need your help, Mia. Please.”]  
    ~ isTalked_mia = true  
    ~ total_points += 2  
    -> gained_mia  

+ [“Stop stalling and tell me what you know.”]  
    ~ isTalked_mia = true  
    ~ total_points -= 1  
    -> pressured_mia  

=== gained_mia ===  
Mia: "Alright. She left this note with me. Said it was important. Be careful."  
+1 Clue (Letter) earned!  

Letter Description: *A coded note from Elysia: “NeuroDyne is hunting me. If you find this, I’m in hiding.”*  
-> END  

=== pressured_mia ===  
Mia: "Here, take the note she left. Now leave me alone."  
+1 Clue (Letter) earned!  
-> END  

=== already_chose_mia ===  
Mia: "I already gave you the note. What else do you want?"  
-> END  
