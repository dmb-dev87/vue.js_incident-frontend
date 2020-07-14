<template>
  <v-container id="user-22222" fluid tag="section">
    <v-row justify="center">
      <v-col cols="12" md="11">
        <v-col cols="12" md="3" style="float:right">
          <v-text-field class="mx-4" flat hide-details label="بحث.." append-icon="mdi-magnify">
            <input v-model="searchKey" id="input-13" type="text" />
          </v-text-field>
        </v-col>

        <v-tooltip top>
          <template v-slot:activator="{ on }">
            <v-col cols="12" md="1" style="float:left">
              <v-btn @click="onAddTask" fab x-small color="green" v-on="on">
                <v-icon light>mdi-plus</v-icon>
              </v-btn>
            </v-col>
          </template>
          <span>إضافة مهمة جديدة</span>
        </v-tooltip>
      </v-col>
    </v-row>
    <v-row justify="center">
      <v-col cols="12" md="11">
        <base-material-card title="كل المهام">
          <v-data-table
            :headers="getTableHeaders"
            :items="allTasks"
            item-key="id"
            :items-per-page="5"
            class="elevation-1"
          >
            <template v-slot:top>
              <v-toolbar flat color="white">
                <v-dialog v-model="dialog" max-width="1500px">
                  <v-card>
                    <base-material-card>
                      <template v-slot:heading></template>
                      <template>
                        <v-tabs background-color="transparent" slider-color="white">
                          <v-tab class="mr-3">
                            <v-icon class="mr-2">mdi-email</v-icon>تفاصيل المهمة
                          </v-tab>
                          <v-tab-item>
                            <form >
                              <v-card class="d-flex pa-2" outlined tile>
                                <div>
                                  
                                </div>
                              </v-card>
                            </form>
                          </v-tab-item>
                          <v-tab class="mr-3">
                            <v-icon class="mr-2">mdi-email</v-icon>الإجراء
                          </v-tab>
                          <v-tab-item></v-tab-item>
                          <v-tab class="mr-3">
                            <v-icon class="mr-2">mdi-email</v-icon>التعليقات
                          </v-tab>
                          <v-tab-item></v-tab-item>
                        </v-tabs>
                      </template>
                    </base-material-card>
                  </v-card>
                </v-dialog>
              </v-toolbar>
            </template>

            <template v-slot:item.actions="{ item }">
              <v-icon medium class="mr-2" @click="showDetails(item.id)">mdi-pencil</v-icon>
            </template>
          </v-data-table>
        </base-material-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import { mapGetters, mapActions, mapMutations, mapState } from "vuex";
import AddTaskDialog from "./AddTaskDialog";
import EditTaskDialog from "./EditTaskDialog";
import Actions from "./TaskActions";

export default {
  components: {
    AddTaskDialog
  },
  data() {
    return {
      searchKey: "",
      dialog: false
    };
  },
  watch: {
    searchKey: function() {
      this.$store.dispatch("apt/setKey", this.searchKey);
    }
  },
  computed: {
    ...mapState("tasks", ["defaultTask"]),
    ...mapGetters("tasks", ["allTasks", "getTableHeaders", "taskById"]),
    ...mapGetters("tasks", [
      "getWhight",
      "getImportance",
      "getUrgancy",
      "getSelectedTask"
    ])
  },
  methods: {
    ...mapActions("tasks", ["fetchTasks", "addTask"]),
    ...mapMutations("tasks", ["setAddTaskDialog"]),

    sendData() {
      this.addTask(this.task);
    },
    onAddTask() {
      // this.setAddTaskDialog(true);
      this.$router.push("AddTaskDialog");
    },
    showDetails(item_id) {
      this.dialog = true;
    }
  },
  mounted() {},
  created() {
    this.fetchTasks();
  }
};
</script>
