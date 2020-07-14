<template>
  <v-container
    id="user-22222"
    fluid
    tag="section"
   >

    <v-row justify="center">
      <v-col cols="12" md="11">
        <base-material-card icon="mdi-clipboard-text" class="px-5 py-3">

            <template v-slot:heading>
            <div class="display-2 font-weight-light"> Task </div>
            </template>
            <h2> {{ getSelectedTask.title }} </h2>
            <h4> {{ getSelectedTask.description }}</h4>
            
                <v-row>
                   
                </v-row>

        </base-material-card>
      </v-col>
    </v-row>

        <v-row justify="center">
      <v-col cols="12" md="11">
        <base-material-card icon="mdi-clipboard-text" class="px-5 py-3">

            <template v-slot:heading>
            <div class="display-2 font-weight-light"> Comments </div>
            </template>

              <template v-for="item in getSelectedTask.comments">
                   <v-row :key = "item">
                     <card :comment="item"/>
                    </v-row>
                    <v-divider :key = "item"></v-divider>
             </template>

                <v-row>
                    <v-col cols="12" md="12">
                        <v-text-field
                        v-model="comment.commentString"
                            label="Comment"
                        />
                        <v-btn
                            color="success"
                            class="mr-0"
                            @click="addComment"
                        >
                            Comment
                        </v-btn>
                    </v-col>
                </v-row>

        </base-material-card>
      </v-col>
    </v-row>  </v-container>

</template>

<script>

import { mapGetters,mapActions, mapMutations, mapState } from 'vuex';
import card from './TaskComment';

  export default {
    components: {
      card
    },
    data () {
      return {
        comment : {
            commentString : '',commentedBy : '',commentedIn : "12-12-2233"
        }        
      }
    },
    computed: {
      ...mapState("tasks",['defaultTask']),
      ...mapGetters("tasks",['getSelectedTask']),
      },
    methods: {
      ...mapActions("tasks",['updateTask','addCommentToTask']),
      addComment() {
          let submit =  Object.assign({}, this.comment);
          this.comment.commentString ='';
          this.addCommentToTask(submit);
          this.updateTask(this.getSelectedTask);
          },
    },mounted (){
    },
  }
</script>
