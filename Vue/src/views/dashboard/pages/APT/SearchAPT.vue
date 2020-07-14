<template>
  <v-container id="user-22222" fluid tag="section">
    <v-row justify="center">
      <v-col cols="12" md="11">
        <!-- <v-col cols="12" md="10">
        <div
          class="v-input v-input--hide-details theme--light v-text-field v-text-field--is-booted"
          style="max-width: 265px;"
        >
          <div class="v-input__control">
            <div class="v-input__slot">
              <div class="v-text-field__slot">
                <label
                  for="input-13"
                  class="v-label theme--light"
                  style="left: 0px; right: auto; position: absolute;"
                >بحث</label>
                <input v-model="searchKey" id="input-13" type="text" />
              </div>
            </div>
          </div>
          <div class="v-input__append-outer">
            <button
              type="button"
              class="mt-n2 v-btn v-btn--fab v-btn--round theme--light elevation-1 v-size--small"
            >
              <span class="v-btn__content">
                <i aria-hidden="true" class="v-icon notranslate mdi mdi-magnify theme--light"></i>
              </span>
            </button>
          </div>
        </div>
        </v-col>-->

        <v-col cols="12" md="3" style="float:right">
          <v-text-field class="mx-4" flat hide-details label="بحث.." append-icon="mdi-magnify">
            <input v-model="searchKey" id="input-13" type="text" />
          </v-text-field>
        </v-col>

        <v-tooltip top>
          <template v-slot:activator="{ on }">
            <v-col cols="12" md="1" style="float:left">
              <v-btn @click="moveToNewApt" fab x-small color="green" v-on="on">
                <v-icon light>mdi-plus</v-icon>
              </v-btn>
            </v-col>
          </template>
          <span>إضافة APT</span>
        </v-tooltip>
      </v-col>
    </v-row>

    <v-row justify="center">
      <v-col cols="12" md="11">
        <base-material-card title="مجموعات التهديد المستمر">
          <v-card-text>
            <v-data-table
              :headers="headers"
              :items="allApts"
              @click:row="viewDetails"
              class="elevation-1"
            >
              <template #item.name="{item}">
                <p v-on:click="viewDetails(item)" style="color:black;">{{item.name}}</p>
              </template>

              <template #item.Details="{item}">
                <p v-html="item.contents[0].contentString" v-if="item.contents.length > 0"></p>
              </template>

              <template #item.signatures="{item}">
                <p v-html="item.threatSignatures[0].name" v-if="item.threatSignatures.length > 0"></p>
              </template>

              <template #item.Actions="{item}">
                <actions :apt="item" />
              </template>
            </v-data-table>
          </v-card-text>
        </base-material-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import actions from "./AptActions";
import { mapGetters, mapActions } from "vuex";
export default {
  components: {
    actions
  },
  data() {
    return {
      searchKey: "",
      headers: [
        {
          text: "إسم االمجموعة",
          align: "start",
          sortable: false,
          value: "name"
        },
        { text: "الملخص", value: "Details" },
        { text: "معرفات", value: "signatures" },
        { text: "االملاحظات", value: "Actions" }
      ]
    };
  },
  watch: {
    searchKey: function() {
      this.$store.dispatch("apt/setKey", this.searchKey);
    }
  },
  computed: {
    ...mapGetters("apt", ["allApts"])
  },
  mounted() {},
  methods: {
    ...mapActions("apt", ["fetchApts", "setKey"]),
    handleClick(value) {
      console.log(value);
    },
    viewDetails(item) {
      this.$store.dispatch("apt/selectedApt", item),
        this.$router.push("DisplayAPT");
    },
    moveToNewApt() {
      this.$router.push("AddApt");
    }
  },
  created() {
    this.fetchApts();
  }
};
</script>
