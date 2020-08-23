<template>
  <div id="app">
    <div v-if="!isUserLoggedIn">
      <div>
        <img
          class="login-background glass"
          src="https://picsum.photos/1920/1080"
          alt="random login picture"
        />

        <router-view />
      </div>
    </div>
    <div v-else>
      <transition name="fade">
        <router-view />
      </transition>
    </div>
  </div>
</template>
<style lang="scss">
html {
  width: 100vw;
  height: 100vh;
}

.login-background {
  width: 100%;
  height: 100%;
  background-size: cover;
  position: absolute;
}

.glass:after {
  filter: blur(5px);
  background-color: rgba(255, 255, 255, 0.15);
}
.glass {
  filter: blur(5px);
  background-color: rgba(255, 255, 255, 0.15);
}

@import "~bulma/sass/utilities/_all";
$primary: $primary;
$primary-invert: findColorInvert($primary);
$twitter: #4099ff;
$twitter-invert: findColorInvert($twitter);
$colors: (
  "white": (
    $white,
    $black
  ),
  "black": (
    $black,
    $white
  ),
  "light": (
    $light,
    $light-invert
  ),
  "dark": (
    $dark,
    $dark-invert
  ),
  "primary": (
    $primary,
    $primary-invert
  ),
  "info": (
    $info,
    $info-invert
  ),
  "success": (
    $success,
    $success-invert
  ),
  "warning": (
    $warning,
    $warning-invert
  ),
  "danger": (
    $danger,
    $danger-invert
  ),
  "twitter": (
    $twitter,
    $twitter-invert
  )
);
$colors: mergeColorMaps(
  (
    "white": (
      $white,
      $black
    ),
    "black": (
      $black,
      $white
    ),
    "light": (
      $light,
      $light-invert
    ),
    "dark": (
      $dark,
      $dark-invert
    ),
    "primary": (
      $primary,
      $primary-invert,
      $primary-light,
      $primary-dark
    ),
    "link": (
      $link,
      $link-invert,
      $link-light,
      $link-dark
    ),
    "info": (
      $info,
      $info-invert,
      $info-light,
      $info-dark
    ),
    "success": (
      $success,
      $success-invert,
      $success-light,
      $success-dark
    ),
    "warning": (
      $warning,
      $warning-invert,
      $warning-light,
      $warning-dark
    ),
    "danger": (
      $danger,
      $danger-invert,
      $danger-light,
      $danger-dark
    )
  ),
  $custom-colors
);
$shades: mergeColorMaps(
  (
    "black-bis": $black-bis,
    "black-ter": $black-ter,
    "grey-darker": $grey-darker,
    "grey-dark": $grey-dark,
    "grey": $grey,
    "grey-light": $grey-light,
    "grey-lighter": $grey-lighter,
    "white-ter": $white-ter,
    "white-bis": $white-bis
  ),
  $custom-shades
);
// Links
$link: $primary;
$link-invert: $primary-invert;
$link-focus-border: $primary;
// Import Bulma and Buefy styles
@import "~bulma";
@import "~buefy/src/scss/buefy";
</style>
<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator";
import Login from "@/components/Login/Login.vue";
@Component({
  components: {
    Login
  }
})
export default class App extends Vue {
  public isUserLoggedIn = false;
  mounted() {
    if (!this.$store.state.User) {
      this.$router.push("login");
    } else {
      this.isUserLoggedIn = true;
    }
  }
}
</script>
