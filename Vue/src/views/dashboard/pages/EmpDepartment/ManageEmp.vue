<template>
  <v-form ref="form" lazy-validation>
    <v-row justify="center">
      <v-col cols="12" md="11">
        <v-row>
          <v-col cols="12" md="4">
            <v-select
              v-model="department"
              :items="GetSector"
              :rules="[v => !!v || 'نسيت اختيار القسم']"
              item-text="value"
              item-value="id"
              label="القسم"
              required
            ></v-select>
          </v-col>

          <v-col cols="12" md="5">
            <v-text-field
              v-model="org"
              :rules="[v => !!v || 'نسيت اختيار الموظف']"
              placeholder="الموظف"
              label="الموظف"
              required
              clearable
            />
          </v-col>

          <v-col cols="12" md="3" class="text-center">
            <v-card-actions>
              <v-btn color="light green" class="mr-0" @click="sendData">
                <h3>إضافة</h3>
              </v-btn>
            </v-card-actions>
          </v-col>
        </v-row>

        <v-row>
          <v-col cols="12" md="12">
            <v-data-table
              :headers="myheaders"
              :items="modifyOrgs"
              :items-per-page="5"
              class="elevation-1"
              dense
              group-by="department"
                          show-group-by  
            >
              <template v-slot:item.actions="{ item }">
                <v-icon @click="deleteItemOrg(item.id)">mdi-delete</v-icon>
              </template>
            </v-data-table>
          </v-col>
        </v-row>
      </v-col>
    </v-row>
    <!-- Alerts  -->
    <v-snackbar v-model="alert.status" :color="alert.color" :timeout="alert.timeout">{{ alert.txt }}</v-snackbar>
  </v-form>
</template>

<script>
import { mapActions, mapGetters, mapState } from "vuex";
export default {
  data() {
    return {
      sector: null,
      org: null,
      myheaders: [
        { text: "القسم", value: "department" },
        { text: "الموظف", value: "name" },
        { text: "الاجراء", value: "actions" }
      ],
      alert: {
        status: false,
        color: null,
        txt: null,
        timeout: 2000
      }
    };
  },

  computed: {
    ...mapGetters("departments", ["GetSector"]),
    ...mapState("departments", ["employees", "departments"]),
    modifyOrgs() {
      return this.employees.map(org => {
        return {
          id: org.id,
          name: org.name,
          department: this.departments.find(sec => sec.id === org.sectorID).value
        };
      });
    }
  },
  methods: {
    ...mapActions("departments", [
      "AddOrg",
      "changeSector",
      "removeOrganization"
    ]),
    sendData() {
      if (!this.org || !this.department)
        return this.statAlert(
          true,
          "الرجاء التأكد من صحة البانات المدخلة اعلاه",
          "error"
        );
      const obiOrg = {
        id: Math.round(Math.random() * 999999),
        name: this.org,
        sectorID: this.department
      };
      this.AddOrg(obiOrg);
    },
    // Alert
    statAlert(status, txt, color) {
      const alert = this.alert;
      alert.status = status;
      alert.txt = txt;
      alert.color = color;
    },
    // Delete item org in table which in vuex of course
    deleteItemOrg(orgID) {
      this.removeOrganization(orgID);
    }
  },
  mounted() {}
};
</script>
