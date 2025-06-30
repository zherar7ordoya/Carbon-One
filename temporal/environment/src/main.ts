import * as vscode from "vscode";

const SHOW_STATUS_BAR_ITEMS = "graceGray.showStatusBarItems";
const HIDE_STATUS_BAR_ITEMS = "graceGray.hideStatusBarItems";
const SHOW_NOTIFICATIONS = "graceGray.showNotifications";
const SHOW_PROGRESS_NOTIFICATION = "graceGray.showProgressNotification";
const SHOW_PROGRESS_IN_WINDOW = "graceGray.showProgressInWindow";

export function activate(context: vscode.ExtensionContext) {
    let warning = vscode.window.createStatusBarItem(vscode.StatusBarAlignment.Left);
    warning.text = "Warning";
    warning.tooltip = "Click to hide";
    warning.command = HIDE_STATUS_BAR_ITEMS;
    warning.backgroundColor = new vscode.ThemeColor("statusBarItem.warningBackground");
    let error = vscode.window.createStatusBarItem(vscode.StatusBarAlignment.Left);
    error.text = "Error";
    error.tooltip = "Click to hide";
    error.command = HIDE_STATUS_BAR_ITEMS;
    error.backgroundColor = new vscode.ThemeColor("statusBarItem.errorBackground");
    function progressTask(
        progress: vscode.Progress<{increment: number, message: string}>,
        _token: vscode.CancellationToken
    ) {
        progress.report({
            message: "10 seconds remaining",
            increment: 0,
        });
        for(let i = 1; i <= 10; i++) {
            setTimeout(
                () => progress.report({
                    message: `${10 - i} seconds remaining`,
                    increment: 10,
                }),
                i * 1000
            );
        }
        return new Promise(resolve => setTimeout(() => resolve(undefined), 11000));
    }
    context.subscriptions.push(
        warning,
        error,
        vscode.commands.registerCommand(SHOW_STATUS_BAR_ITEMS, () => {
            warning.show();
            error.show();
        }),
        vscode.commands.registerCommand(HIDE_STATUS_BAR_ITEMS, () => {
            warning.hide();
            error.hide();
        }),
        vscode.commands.registerCommand(SHOW_NOTIFICATIONS, () => {
            vscode.window.showInformationMessage(
                "This is an information", "Yes", "No", "Cancel"
            );
            vscode.window.showWarningMessage("This is a warning");
            vscode.window.showErrorMessage("This is an Error");
        }),
        vscode.commands.registerCommand(SHOW_PROGRESS_NOTIFICATION, () => {
            vscode.window.withProgress({
                location: vscode.ProgressLocation.Notification,
                title: "Progress"
            }, progressTask);
        }),
        vscode.commands.registerCommand(SHOW_PROGRESS_IN_WINDOW, () => {
            vscode.window.withProgress({
                location: vscode.ProgressLocation.Window,
                title: "Progress"
            }, progressTask);
        }),
    );
}