import { ModernStore.AppPage } from './app.po';

describe('modern-store.app App', () => {
  let page: ModernStore.AppPage;

  beforeEach(() => {
    page = new ModernStore.AppPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
