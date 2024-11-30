INCLUDE globals.ink

{isTalked_liam == false : -> main_liam | -> already_chose_liam}

=== main_liam ===  
Alex find Liam, a cynical ex-cop leaning against a wall near the café.  

+ [“I’m not backing down. Tell me what you know about Elysia.”]  
    ~ isTalked_liam = true  
    ~ total_points += 2  
    -> pleaded_liam  

+ [“You don’t have a choice, Liam. Start talking.”]  
    ~ isTalked_liam = true  
    ~ total_points -= 1  
    -> threatened_liam  

=== pleaded_liam ===  
Liam: "Fine. I saw her running from some shady-looking guys. She dropped this photo in the alley near the nightclub."  
+1 Clue (Photo) earned!  

Photo Description: *A blurry photo of Elysia running, with a shadowy figure chasing her.*  
-> END  

=== threatened_liam ===  
Liam: "She dropped a photo in the nightclub alley. Just Leave me alone."  
-> END  

=== already_chose_liam ===  
Liam: "I’ve got nothing else for you."  
-> END  
