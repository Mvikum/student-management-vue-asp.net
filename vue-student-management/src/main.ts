import { createApp } from 'vue';

// Vuetify
import 'vuetify/styles';
import { createVuetify } from 'vuetify';
import * as components from 'vuetify/components';
import * as directives from 'vuetify/directives';

// Components
import App from './App.vue';

// Router
import router from './router'; // Import the router configuration

const vuetify = createVuetify({
  components,
  directives,
});

createApp(App)
  .use(vuetify)  // Using Vuetify
  .use(router)   // Using Vue Router
  .mount('#app');
