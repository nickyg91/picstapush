<style lang="scss" scoped>
.login-box {
  z-index: 1;
  position: relative;
}
</style>
<template>
  <section class="section">
    <div class="container">
      <div class="column is-offset-one-third is-one-third">
        <div class="box">
          <div>
            <h2 class="is-size-1">Picstapush</h2>
          </div>
          <b-field label="Username">
            <b-input placeholder="Username" type="text" icon="user"></b-input>
          </b-field>
          <b-field label="Password">
            <b-input type="Password" placeholder="Password" password-reveal icon="lock"></b-input>
          </b-field>
          <div class="is-centered buttons">
            <button class="button is-outlined is-primary">
              <span class="icon">
                <i class="fas fa-sign-in-alt"></i>
              </span>
              <span>Log in</span>
            </button>
            <button class="button is-outlined is-info">
              <span class="icon">
                <i class="fas fa-user-plus"></i>
              </span>
              <span>Sign Up</span>
            </button>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>
<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator";
import User from "@/models/user-model";
@Component
export default class Login extends Vue {
  public user = new User();
}
</script>